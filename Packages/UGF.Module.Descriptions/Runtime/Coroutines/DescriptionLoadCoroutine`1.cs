using System;
using System.Collections;
using UGF.Coroutines.Runtime;
using UGF.Description.Runtime;
using UGF.Module.Assets.Runtime;
using UGF.Module.Serialize.Runtime;
using UGF.Serialize.Runtime;
using UnityEngine;

namespace UGF.Module.Descriptions.Runtime.Coroutines
{
    public class DescriptionLoadCoroutine<TDescription> : Coroutine<TDescription> where TDescription : IDescription
    {
        public IAssetsModule AssetsModule { get; }
        public ISerializeModule SerializeModule { get; }
        public string AssetName { get; }

        public DescriptionLoadCoroutine(IAssetsModule assetsModule, ISerializeModule serializeModule, string assetName)
        {
            if (string.IsNullOrEmpty(assetName)) throw new ArgumentException("Value cannot be null or empty.", nameof(assetName));

            AssetsModule = assetsModule ?? throw new ArgumentNullException(nameof(assetsModule));
            SerializeModule = serializeModule ?? throw new ArgumentNullException(nameof(serializeModule));
            AssetName = assetName;
        }

        protected override IEnumerator Routine()
        {
            ICoroutine<object> assetCoroutine = AssetsModule.LoadAsync<object>(AssetName);

            yield return assetCoroutine;

            object asset = assetCoroutine.Result;
            TDescription result;

            switch (asset)
            {
                case DescriptionAsset descriptionAsset:
                {
                    result = descriptionAsset.GetDescription<TDescription>();
                    break;
                }
                case TextAsset textAsset:
                {
                    ISerializer<byte[]> serializer = SerializeModule.GetDefaultBytesSerializer();

                    result = serializer.Deserialize<TDescription>(textAsset.bytes);
                    break;
                }
                default: throw new ArgumentException($"Unexpected asset type: '{asset}'.", nameof(asset));
            }

            Result = result;

            AssetsModule.Release(asset);
        }
    }
}
