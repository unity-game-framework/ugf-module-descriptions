using System;
using System.Collections.Generic;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Descriptions.Runtime
{
    public abstract class DescriptionCollectionAsset : DescriptionAsset
    {
        public void GetDescriptions(IDictionary<GlobalId, IDescription> descriptions)
        {
            if (descriptions == null) throw new ArgumentNullException(nameof(descriptions));

            OnGetDescriptions(descriptions);
        }

        protected abstract void OnGetDescriptions(IDictionary<GlobalId, IDescription> descriptions);
    }
}
