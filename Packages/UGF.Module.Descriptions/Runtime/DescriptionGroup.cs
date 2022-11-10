using System.Collections.Generic;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Descriptions.Runtime
{
    public class DescriptionGroup : IDescription
    {
        public Dictionary<GlobalId, GlobalId> Descriptions { get; } = new Dictionary<GlobalId, GlobalId>();
    }
}
