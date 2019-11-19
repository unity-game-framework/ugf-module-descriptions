using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Description.Runtime;
using UGF.Logs.Runtime;
using UGF.Module.Assets.Runtime;
using UGF.Module.Serialize.Runtime;
using UGF.Serialize.Runtime;
using UnityEngine;

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

        public override async Task InitializeAsync()
        {
            IReadOnlyList<IDescriptionAssetInfo> assetInfos = Description.AssetInfos;

            for (int i = 0; i < assetInfos.Count; i++)
            {
                IDescriptionAssetInfo assetInfo = assetInfos[i];
                IDescription description = await LoadAsync(assetInfo.AssetName, typeof(IDescription));

                Add(assetInfo.RegisterName, description);

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

        public T Load<T>(string assetName) where T : IDescription
        {
            var asset = AssetsModule.Load<object>(assetName);
            var description = ExtractDescription<T>(asset, typeof(T));

            AssetsModule.Release(asset);

            return description;
        }

        public IDescription Load(string assetName, Type assetType)
        {
            var asset = AssetsModule.Load<object>(assetName);
            var description = ExtractDescription<IDescription>(asset, assetType);

            AssetsModule.Release(asset);

            return description;
        }

        public async Task<T> LoadAsync<T>(string assetName) where T : IDescription
        {
            object asset = await AssetsModule.LoadAsync<object>(assetName);
            var description = ExtractDescription<T>(asset, typeof(T));

            AssetsModule.Release(asset);

            return description;
        }

        public async Task<IDescription> LoadAsync(string assetName, Type assetType)
        {
            object asset = await AssetsModule.LoadAsync<object>(assetName);
            var description = ExtractDescription<IDescription>(asset, assetType);

            AssetsModule.Release(asset);

            return description;
        }

        private T ExtractDescription<T>(object asset, Type assetType) where T : IDescription
        {
            switch (asset)
            {
                case DescriptionAsset descriptionAsset:
                {
                    return descriptionAsset.GetDescription<T>();
                }
                case TextAsset textAsset:
                {
                    ISerializer<byte[]> serializer = SerializeModule.GetDefaultBytesSerializer();

                    return typeof(T) == typeof(IDescription)
                        ? (T)serializer.Deserialize(assetType, textAsset.bytes)
                        : serializer.Deserialize<T>(textAsset.bytes);
                }
                default: throw new ArgumentException($"Unexpected asset type: '{asset}'.", nameof(asset));
            }
        }
    }
}
