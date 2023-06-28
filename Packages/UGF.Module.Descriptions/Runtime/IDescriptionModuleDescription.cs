using System.Collections.Generic;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Descriptions.Runtime
{
    public interface IDescriptionModuleDescription
    {
        IReadOnlyDictionary<GlobalId, IDescription> Descriptions { get; }
        IReadOnlyList<GlobalId> LoadAsync { get; }
    }
}
