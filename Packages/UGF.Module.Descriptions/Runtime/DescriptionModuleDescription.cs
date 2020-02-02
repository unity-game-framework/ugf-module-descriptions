using System.Collections.Generic;

namespace UGF.Module.Descriptions.Runtime
{
    public class DescriptionModuleDescription : IDescriptionModuleDescription
    {
        public List<string> Assets { get; set; } = new List<string>();

        IReadOnlyList<string> IDescriptionModuleDescription.Assets { get { return Assets; } }
    }
}
