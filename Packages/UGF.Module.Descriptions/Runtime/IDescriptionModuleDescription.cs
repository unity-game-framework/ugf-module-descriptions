using System.Collections.Generic;

namespace UGF.Module.Descriptions.Runtime
{
    public interface IDescriptionModuleDescription
    {
        IReadOnlyDictionary<string, string> Assets { get; }
    }
}
