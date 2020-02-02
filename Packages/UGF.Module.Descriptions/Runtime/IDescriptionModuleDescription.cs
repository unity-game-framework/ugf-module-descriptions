using System.Collections.Generic;

namespace UGF.Module.Descriptions.Runtime
{
    public interface IDescriptionModuleDescription
    {
        IReadOnlyList<string> Assets { get; }
    }
}
