using UGF.Application.Runtime;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Descriptions.Runtime
{
    public interface IDescriptionModule : IApplicationModule
    {
        new IDescriptionModuleDescription Description { get; }

        T Get<T>(GlobalId id) where T : class, IDescription;
        IDescription Get(GlobalId id);
        bool TryGet<T>(GlobalId id, out T description) where T : class, IDescription;
        bool TryGet(GlobalId id, out IDescription description);
    }
}
