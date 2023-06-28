using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UGF.Module.Assets.Runtime;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Descriptions.Runtime
{
    public class DescriptionModule : ApplicationModuleAsync<DescriptionModuleDescription>, IDescriptionModule
    {
        public Provider<GlobalId, IDescription> Provider { get; } = new Provider<GlobalId, IDescription>();

        IProvider<GlobalId, IDescription> IDescriptionModule.Provider { get { return Provider; } }
        IDescriptionModuleDescription IDescriptionModule.Description { get { return Description; } }

        protected IAssetModule AssetModule { get; }

        public DescriptionModule(DescriptionModuleDescription description, IApplication application) : base(description, application)
        {
            AssetModule = Application.GetModule<IAssetModule>();
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            foreach ((GlobalId id, IDescription description) in Description.Descriptions)
            {
                Provider.Add(id, description);
            }
        }

        protected override async Task OnInitializeAsync()
        {
            await base.OnInitializeAsync();
            await LoadFromAssetsAsync(Description.LoadAsync);
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            Provider.Clear();
        }

        public T Get<T>(GlobalId id) where T : class, IDescription
        {
            return (T)Get(id);
        }

        public IDescription Get(GlobalId id)
        {
            return TryGet(id, out IDescription description) ? description : throw new ArgumentException($"Description not found by the specified id: '{id}'.");
        }

        public bool TryGet<T>(GlobalId id, out T description) where T : class, IDescription
        {
            if (TryGet(id, out IDescription result))
            {
                description = (T)result;
                return true;
            }

            description = default;
            return false;
        }

        public bool TryGet(GlobalId id, out IDescription description)
        {
            if (!id.IsValid()) throw new ArgumentException("Value should be valid.", nameof(id));

            return Provider.TryGet(id, out description);
        }

        public async Task LoadFromAssetsAsync(IReadOnlyList<GlobalId> assetIds)
        {
            if (assetIds == null) throw new ArgumentNullException(nameof(assetIds));

            for (int i = 0; i < assetIds.Count; i++)
            {
                GlobalId assetId = assetIds[i];

                var asset = await AssetModule.LoadAsync<DescriptionAsset>(assetId);

                Provider.Add(assetId, asset.Build());

                if (asset is DescriptionCollectionListAsset collection)
                {
                    collection.GetDescriptions(Provider);
                }

                await AssetModule.UnloadAsync(assetId, asset);
            }
        }
    }
}
