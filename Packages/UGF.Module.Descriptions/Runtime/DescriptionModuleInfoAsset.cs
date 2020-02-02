using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.IMGUI;
using UGF.Module.Assets.Runtime;
using UGF.Module.Serialize.Runtime;
using UnityEngine;

namespace UGF.Module.Descriptions.Runtime
{
    [CreateAssetMenu(menuName = "UGF/Module.Descriptions/DescriptionModuleInfo", order = 2000)]
    public class DescriptionModuleInfoAsset : ApplicationModuleInfoAsset<IDescriptionModule>
    {
        [SerializeField, AssetGuid] private List<string> m_assets = new List<string>();

        public List<string> Assets { get { return m_assets; } }

        public IDescriptionModuleDescription GetDescription()
        {
            return new DescriptionModuleDescription
            {
                Assets = new List<string>(m_assets)
            };
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
