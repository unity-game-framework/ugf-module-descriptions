using System.Collections.Generic;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Descriptions.Runtime
{
    public class DescriptionGroup : IDescription
    {
        public Dictionary<GlobalId, IDescription> Descriptions { get; } = new Dictionary<GlobalId, IDescription>();
    }
}
