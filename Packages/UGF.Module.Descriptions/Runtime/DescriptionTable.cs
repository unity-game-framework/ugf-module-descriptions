using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Descriptions.Runtime
{
    public class DescriptionTable<TDescription> : Provider<GlobalId, TDescription>, IDescriptionTable<TDescription> where TDescription : IDescription
    {
    }
}
