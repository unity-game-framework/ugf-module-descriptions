using System;
using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Descriptions.Runtime
{
    public class DescriptionModuleDescription : ApplicationModuleDescription, IDescriptionModuleDescription
    {
        public Dictionary<GlobalId, IDescription> Descriptions { get; }
        public IReadOnlyList<GlobalId> LoadAsync { get; }

        IReadOnlyDictionary<GlobalId, IDescription> IDescriptionModuleDescription.Descriptions { get { return Descriptions; } }

        public DescriptionModuleDescription(Type registerType, Dictionary<GlobalId, IDescription> descriptions, IReadOnlyList<GlobalId> loadAsync) : base(registerType)
        {
            Descriptions = descriptions ?? throw new ArgumentNullException(nameof(descriptions));
            LoadAsync = loadAsync ?? throw new ArgumentNullException(nameof(loadAsync));
        }
    }
}
