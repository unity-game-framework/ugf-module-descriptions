using System;
using System.Collections;
using UGF.Coroutines.Runtime;
using UGF.Module.Assets.Runtime;
using UGF.Module.Serialize.Runtime;
using UGF.Serialize.Runtime;
using UnityEngine;

namespace UGF.Module.Descriptions.Runtime.Coroutines
{
    public class DescriptionLoadTextAssetCoroutine<TResult> : Coroutine<TResult>
    {
        public IAssetsModule AssetsModule { get; }
        public ISerializeModule SerializeModule { get; }
        public string AssetName { get; }

        public DescriptionLoadTextAssetCoroutine(IAssetsModule assetsModule, ISerializeModule serializeModule, string assetName)
        {
            if (string.IsNullOrEmpty(assetName)) throw new ArgumentException("Value cannot be null or empty.", nameof(assetName));

            AssetsModule = assetsModule ?? throw new ArgumentNullException(nameof(assetsModule));
            SerializeModule = serializeModule ?? throw new ArgumentNullException(nameof(serializeModule));
            AssetName = assetName;
        }

        protected override IEnumerator Routine()
        {
            ICoroutine<TextAsset> assetCoroutine = AssetsModule.LoadAsync<TextAsset>(AssetName);

            yield return assetCoroutine;

            TextAsset asset = assetCoroutine.Result;
            ISerializer<byte[]> serializer = SerializeModule.GetDefaultBytesSerializer();
            var result = serializer.Deserialize<TResult>(asset.bytes);

            Result = result;

            AssetsModule.Release(asset);
        }
    }
}
