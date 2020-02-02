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
    public class DescriptionModule : ApplicationModuleBase, IDescriptionModule, IApplicationModuleAsync
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

        public async Task InitializeAsync()
        {
            IReadOnlyList<string> assets = Description.Assets;

            for (int i = 0; i < assets.Count; i++)
            {
                string assetId = assets[i];
                var description = await LoadAsync<IDescription>(assetId);

                Add(assetId, description);
            }

            Log.Debug($"Descriptions total: count:'{assets.Count.ToString()}'.");
        }

        public void Add(string id, IDescription description)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));
            if (description == null) throw new ArgumentNullException(nameof(description));
            if (m_descriptions.ContainsKey(id)) throw new ArgumentException($"Description with the specified id already registered: '{id}'.", nameof(id));

            m_descriptions.Add(id, description);
        }

        public void Remove(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            m_descriptions.Remove(id);
        }

        public T GetDescription<T>(string id) where T : IDescription
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            if (!TryGetDescription(id, out T description))
            {
                throw new ArgumentException($"Description by the specified id not found: '{id}'.");
            }

            return description;
        }

        public bool TryGetDescription<T>(string id, out T description) where T : IDescription
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            if (m_descriptions.TryGetValue(id, out IDescription value) && value is T cast)
            {
                description = cast;
                return true;
            }

            description = default;
            return false;
        }

        public T Load<T>(string assetName) where T : IDescription
        {
            return (T)Load(assetName, typeof(T));
        }

        public IDescription Load(string assetName, Type assetType)
        {
            var asset = AssetsModule.Load<object>(assetName);
            IDescription description = ExtractDescription(asset, assetType);

            AssetsModule.Release(asset);

            return description;
        }

        public async Task<T> LoadAsync<T>(string assetName) where T : IDescription
        {
            return (T)await LoadAsync(assetName, typeof(T));
        }

        public async Task<IDescription> LoadAsync(string assetName, Type assetType)
        {
            var asset = await AssetsModule.LoadAsync<object>(assetName);
            IDescription description = ExtractDescription(asset, assetType);

            AssetsModule.Release(asset);

            return description;
        }

        private IDescription ExtractDescription(object asset, Type assetType)
        {
            switch (asset)
            {
                case DescriptionAsset descriptionAsset:
                {
                    return descriptionAsset.GetDescription();
                }
                case TextAsset textAsset:
                {
                    ISerializer<string> serializer = SerializeModule.GetDefaultTextSerializer();

                    return (IDescription)serializer.Deserialize(assetType, textAsset.text);
                }
                default: throw new ArgumentException($"Unexpected asset type: '{asset}'.", nameof(asset));
            }
        }
    }
}
