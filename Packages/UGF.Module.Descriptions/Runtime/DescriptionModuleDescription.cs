using System.Collections.Generic;

namespace UGF.Module.Descriptions.Runtime
{
    public class DescriptionModuleDescription : IDescriptionModuleDescription
    {
        public Dictionary<string, string> Assets { get; set; } = new Dictionary<string, string>();

        IReadOnlyDictionary<string, string> IDescriptionModuleDescription.Assets { get { return Assets; } }
    }
}
