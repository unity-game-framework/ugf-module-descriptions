using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Descriptions.Runtime
{
    public class DescriptionModuleDescription : ApplicationModuleDescription, IDescriptionModuleDescription
    {
        public Dictionary<GlobalId, IDescription> Descriptions { get; } = new Dictionary<GlobalId, IDescription>();
    }
}
