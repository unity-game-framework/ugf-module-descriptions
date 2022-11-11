using System.Collections.Generic;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Descriptions.Runtime
{
    public class DescriptionCollectionDescription : DescriptionBase
    {
        public List<GlobalId> DescriptionIds { get; } = new List<GlobalId>();
    }
}
