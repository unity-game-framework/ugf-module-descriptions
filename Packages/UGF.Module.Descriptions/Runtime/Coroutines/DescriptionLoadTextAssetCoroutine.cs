using System;
using System.Collections;
using UGF.Coroutines.Runtime;
using UGF.Module.Assets.Runtime;
using UGF.Module.Serialize.Runtime;
using UGF.Serialize.Runtime;
using UnityEngine;

namespace UGF.Module.Descriptions.Runtime.Coroutines
{
    public class DescriptionLoadTextAssetCoroutine : Coroutine<object>
    {
        public IAssetsModule AssetsModule { get; }
        public ISerializeModule SerializeModule { get; }
        public string AssetName { get; }
        public Type TargetType { get; }

        public DescriptionLoadTextAssetCoroutine(IAssetsModule assetsModule, ISerializeModule serializeModule, string assetName, Type targetType)
        {
            if (string.IsNullOrEmpty(assetName)) throw new ArgumentException("Value cannot be null or empty.", nameof(assetName));

            AssetsModule = assetsModule ?? throw new ArgumentNullException(nameof(assetsModule));
            SerializeModule = serializeModule ?? throw new ArgumentNullException(nameof(serializeModule));
            AssetName = assetName;
            TargetType = targetType ?? throw new ArgumentNullException(nameof(targetType));
        }

        protected override IEnumerator Routine()
        {
            ICoroutine<TextAsset> assetCoroutine = AssetsModule.LoadAsync<TextAsset>(AssetName);

            yield return assetCoroutine;

            TextAsset asset = assetCoroutine.Result;
            ISerializer<byte[]> serializer = SerializeModule.GetDefaultBytesSerializer();
            object result = serializer.Deserialize(TargetType, asset.bytes);

            Result = result;

            AssetsModule.Release(asset);
        }
    }
}
