using UGF.Description.Runtime;
using UGF.Tables.Runtime;

namespace UGF.Module.Descriptions.Runtime
{
    public interface IDescriptionTableEntry<out TDescription> : ITableEntry where TDescription : IDescription
    {
        TDescription Build();
    }
}
