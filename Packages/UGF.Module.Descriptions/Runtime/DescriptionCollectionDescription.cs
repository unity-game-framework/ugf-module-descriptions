using System;
using System.Collections.Generic;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Descriptions.Runtime
{
    public class DescriptionCollectionDescription : DescriptionBase
    {
        public IReadOnlyList<GlobalId> DescriptionIds { get; }

        public DescriptionCollectionDescription(IReadOnlyList<GlobalId> descriptionIds)
        {
            DescriptionIds = descriptionIds ?? throw new ArgumentNullException(nameof(descriptionIds));
        }
    }
}
