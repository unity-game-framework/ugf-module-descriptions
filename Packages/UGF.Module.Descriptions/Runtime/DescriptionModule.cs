using UGF.Application.Runtime;

namespace UGF.Module.Descriptions.Runtime
{
    public class DescriptionModule : ApplicationModule<DescriptionModuleDescription>, IDescriptionModule
    {
        IDescriptionModuleDescription IDescriptionModule.Description { get { return Description; } }

        public DescriptionModule(DescriptionModuleDescription description, IApplication application) : base(description, application)
        {
        }
    }
}
