using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Descriptions.Runtime
{
    public interface IDescriptionTable<TDescription> : IProvider<GlobalId, TDescription>, IDescriptionTable where TDescription : IDescription
    {
    }
}
