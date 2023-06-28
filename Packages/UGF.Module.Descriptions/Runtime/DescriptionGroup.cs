using System;
using System.Collections.Generic;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Descriptions.Runtime
{
    public class DescriptionGroup : DescriptionBase
    {
        public IReadOnlyDictionary<GlobalId, GlobalId> Descriptions { get; }

        public DescriptionGroup(IReadOnlyDictionary<GlobalId, GlobalId> descriptions)
        {
            Descriptions = descriptions ?? throw new ArgumentNullException(nameof(descriptions));
        }
    }
}
