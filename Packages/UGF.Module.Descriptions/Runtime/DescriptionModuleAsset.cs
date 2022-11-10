using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Module.Descriptions.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Descriptions/Description Module", order = 3000)]
    public class DescriptionModuleAsset : ApplicationModuleAsset<DescriptionModule, DescriptionModuleDescription>
    {
        protected override IApplicationModuleDescription OnBuildDescription()
        {
            var description = new DescriptionModuleDescription
            {
                RegisterType = typeof(IDescriptionModule)
            };

            return description;
        }

        protected override DescriptionModule OnBuild(DescriptionModuleDescription description, IApplication application)
        {
            return new DescriptionModule(description, application);
        }
    }
}
