using UGF.Application.Runtime;
using UGF.Module.Assets.Runtime;
using UGF.Module.Runtime;
using UGF.Module.Serialize.Runtime;
using UnityEngine;

namespace UGF.Module.Descriptions.Runtime
{
    [CreateAssetMenu(menuName = "UGF/Module.Descriptions/DescriptionModuleBuilder", order = 2000)]
    public class DescriptionModuleBuilderAsset : ModuleBuilderAsset<DescriptionModule, DescriptionModuleDescription>
    {
        protected override IApplicationModule OnBuild(IApplication application, DescriptionModuleDescription description)
        {
            var assetsModule = application.GetModule<IAssetsModule>();
            var serializeModule = application.GetModule<ISerializeModule>();

            return new DescriptionModule(assetsModule, serializeModule, description);
        }
    }
}
