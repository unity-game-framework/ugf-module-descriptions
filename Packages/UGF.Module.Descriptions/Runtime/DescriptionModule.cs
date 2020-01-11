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
            IReadOnlyDictionary<string, string> assets = Description.Assets;

            foreach (KeyValuePair<string, string> pair in assets)
            {
                IDescription description = await LoadAsync(pair.Value, typeof(IDescription));

                Add(pair.Key, description);

                Log.Debug($"Description loaded: name:'{pair.Key}', assetName:'{pair.Value}'.");
            }

            Log.Debug($"Descriptions total: count:'{assets.Count.ToString()}'.");
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
