using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Descriptions.Runtime
{
    public interface IDescriptionModule : IApplicationModule
    {
        IDescriptionModuleDescription Description { get; }
        IProvider<GlobalId, IDescription> Provider { get; }

        T Get<T>(GlobalId id) where T : class, IDescription;
        IDescription Get(GlobalId id);
        bool TryGet<T>(GlobalId id, out T description) where T : class, IDescription;
        bool TryGet(GlobalId id, out IDescription description);
        Task<IDescription> LoadAsync(GlobalId id);
        Task<IDescriptionTable> LoadTableAsync(GlobalId id);
    }
}
