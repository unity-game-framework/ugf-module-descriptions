using UGF.Application.Runtime;

namespace UGF.Module.Descriptions.Runtime
{
    public interface IDescriptionModule : IApplicationModule
    {
        new IDescriptionModuleDescription Description { get; }
    }
}
