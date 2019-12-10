using System;
using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.Module.Assets.Runtime;
using UGF.Module.Serialize.Runtime;
using UnityEngine;

namespace UGF.Module.Descriptions.Runtime
{
    [CreateAssetMenu(menuName = "UGF/Module.Descriptions/DescriptionModuleInfo", order = 2000)]
    public class DescriptionModuleInfoAsset : ApplicationModuleInfoAsset<IDescriptionModule>
    {
        [SerializeField] private List<AssetInfo> m_assets = new List<AssetInfo>();

        public List<AssetInfo> Assets { get { return m_assets; } }

        [Serializable]
        public class AssetInfo
        {
            [SerializeField] private string m_name;
            [SerializeField] private string m_assetName;

            public string Name { get { return m_name; } set { m_name = value; } }
            public string AssetName { get { return m_assetName; } set { m_assetName = value; } }
        }

        public IDescriptionModuleDescription GetDescription()
        {
            var description = new DescriptionModuleDescription();

            for (int i = 0; i < m_assets.Count; i++)
            {
                AssetInfo info = m_assets[i];

                description.Assets.Add(info.Name, info.AssetName);
            }

            return description;
        }

        protected override IApplicationModule OnBuild(IApplication application)
        {
            var assetsModule = application.GetModule<IAssetsModule>();
            var serializeModule = application.GetModule<ISerializeModule>();
            IDescriptionModuleDescription description = GetDescription();

            return new DescriptionModule(assetsModule, serializeModule, description);
        }
    }
}
