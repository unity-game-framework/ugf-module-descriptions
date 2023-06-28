using System;
using System.Collections.Generic;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Descriptions.Runtime
{
    public abstract class DescriptionCollectionAsset : DescriptionAsset
    {
        public void GetDescriptions(IDictionary<GlobalId, IDescription> descriptions)
        {
            if (descriptions == null) throw new ArgumentNullException(nameof(descriptions));

            OnGetDescriptions(descriptions);
        }

        public void GetDescriptions(IProvider<GlobalId, IDescription> provider)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));

            OnGetDescriptions(provider);
        }

        protected abstract void OnGetDescriptions(IDictionary<GlobalId, IDescription> descriptions);
        protected abstract void OnGetDescriptions(IProvider<GlobalId, IDescription> provider);
    }
}
