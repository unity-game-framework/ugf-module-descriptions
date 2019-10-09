using System;
using System.Collections;
using UGF.Coroutines.Runtime;
using UGF.Description.Runtime;
using UGF.Module.Assets.Runtime;

namespace UGF.Module.Descriptions.Runtime.Coroutines
{
    public class DescriptionLoadAssetCoroutine : Coroutine<IDescription>
    {
        public IAssetsModule AssetsModule { get; }
        public string AssetName { get; }

        public DescriptionLoadAssetCoroutine(IAssetsModule assetsModule, string assetName)
        {
            if (string.IsNullOrEmpty(assetName)) throw new ArgumentException("Value cannot be null or empty.", nameof(assetName));

            AssetsModule = assetsModule ?? throw new ArgumentNullException(nameof(assetsModule));
            AssetName = assetName;
        }

        protected override IEnumerator Routine()
        {
            ICoroutine<DescriptionAsset> assetCoroutine = AssetsModule.LoadAsync<DescriptionAsset>(AssetName);

            yield return assetCoroutine;

            DescriptionAsset asset = assetCoroutine.Result;

            Result = asset.GetDescription();

            AssetsModule.Release(asset);
        }
    }
}
