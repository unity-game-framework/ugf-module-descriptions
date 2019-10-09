using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UGF.Application.Runtime;
using UGF.Coroutines.Runtime;
using UGF.Description.Runtime;
using UGF.Logs.Runtime;
using UGF.Module.Assets.Runtime;
using UGF.Module.Descriptions.Runtime.Coroutines;
using UGF.Module.Serialize.Runtime;

namespace UGF.Module.Descriptions.Runtime
{
    public class DescriptionModule : ApplicationModuleBaseAsync, IDescriptionModule
    {
        public IAssetsModule AssetsModule { get; }
        public ISerializeModule SerializeModule { get; }
        public IDescriptionModuleDescription Description { get; }
        public IReadOnlyDictionary<string, IDescription> Descriptions { get; }

        private readonly Dictionary<string, IDescription> m_descriptions = new Dictionary<string, IDescription>();

        public DescriptionModule(IAssetsModule assetsModule, ISerializeModule serializeModule, IDescriptionModuleDescription description)
        {
            AssetsModule = assetsModule ?? throw new ArgumentNullException(nameof(assetsModule));
            SerializeModule = serializeModule ?? throw new ArgumentNullException(nameof(serializeModule));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Descriptions = new ReadOnlyDictionary<string, IDescription>(m_descriptions);
        }

        protected override IEnumerator OnInitializeAsync()
        {
            IReadOnlyList<IDescriptionAssetInfo> assetInfos = Description.AssetInfos;

            for (int i = 0; i < assetInfos.Count; i++)
            {
                IDescriptionAssetInfo assetInfo = assetInfos[i];
                ICoroutine<IDescription> coroutine = LoadAsync(assetInfo.AssetName, typeof(IDescription));

                yield return coroutine;

                Add(assetInfo.RegisterName, coroutine.Result);

                Log.Debug($"Description loaded: registerName:'{assetInfo.RegisterName}', assetName:'{assetInfo.AssetName}'.");
            }

            Log.Debug($"Descriptions total: count:'{assetInfos.Count}'.");
        }

        public void Add(string name, IDescription description)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));
            if (description == null) throw new ArgumentNullException(nameof(description));
            if (m_descriptions.ContainsKey(name)) throw new ArgumentException($"A description with the specified name already registered: '{name}'.", nameof(name));

            m_descriptions.Add(name, description);
        }

        public void Remove(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            m_descriptions.Remove(name);
        }

        public T GetDescription<T>(string name) where T : IDescription
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            if (!TryGetDescription(name, out T description))
            {
                throw new ArgumentException($"The description by the specified name not found: '{name}'.");
            }

            return description;
        }

        public bool TryGetDescription<T>(string name, out T description) where T : IDescription
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            if (m_descriptions.TryGetValue(name, out IDescription value) && value is T cast)
            {
                description = cast;
                return true;
            }

            description = default;
            return false;
        }

        public ICoroutine<IDescription> LoadAsync(string assetName, Type assetType)
        {
            if (string.IsNullOrEmpty(assetName)) throw new ArgumentException("Value cannot be null or empty.", nameof(assetName));
            if (assetType == null) throw new ArgumentNullException(nameof(assetType));

            return new DescriptionLoadCoroutine(AssetsModule, SerializeModule, assetName, assetType);
        }

        public ICoroutine<T> LoadAsync<T>(string assetName) where T : IDescription
        {
            if (string.IsNullOrEmpty(assetName)) throw new ArgumentException("Value cannot be null or empty.", nameof(assetName));

            return new DescriptionLoadCoroutine<T>(AssetsModule, SerializeModule, assetName);
        }
    }
}
