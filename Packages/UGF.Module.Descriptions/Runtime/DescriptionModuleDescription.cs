using System;
using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Descriptions.Runtime
{
    public class DescriptionModuleDescription : ApplicationModuleDescription, IDescriptionModuleDescription
    {
        public IReadOnlyDictionary<GlobalId, IDescription> Descriptions { get; }
        public IReadOnlyList<GlobalId> LoadAsync { get; }

        public DescriptionModuleDescription(
            IReadOnlyDictionary<GlobalId, IDescription> descriptions,
            IReadOnlyList<GlobalId> loadAsync)
        {
            Descriptions = descriptions ?? throw new ArgumentNullException(nameof(descriptions));
            LoadAsync = loadAsync ?? throw new ArgumentNullException(nameof(loadAsync));
        }
    }
}
