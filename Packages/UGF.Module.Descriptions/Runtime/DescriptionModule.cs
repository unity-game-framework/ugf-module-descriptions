using System;
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

            for (int i = 0; i < Description.LoadAsync.Count; i++)
            {
                GlobalId id = Description.LoadAsync[i];

                await LoadAsync(id);
            }
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

        public async Task<IDescription> LoadAsync(GlobalId id)
        {
            if (!id.IsValid()) throw new ArgumentException("Value should be valid.", nameof(id));

            var asset = await AssetModule.LoadAsync<DescriptionAsset>(id);

            IDescription description = asset.Build();

            Provider.Add(id, description);

            if (asset is DescriptionCollectionListAsset collection)
            {
                collection.GetDescriptions(Provider);
            }

            await AssetModule.UnloadAsync(id, asset);

            return description;
        }

        public async Task<IDescriptionTable> LoadTableAsync(GlobalId id)
        {
            if (!id.IsValid()) throw new ArgumentException("Value should be valid.", nameof(id));

            var asset = await AssetModule.LoadAsync<DescriptionTableAsset>(id);

            IDescriptionTable description = asset.Build();

            Provider.Add(id, description);

            await AssetModule.UnloadAsync(id, asset);

            return description;
        }
    }
}
