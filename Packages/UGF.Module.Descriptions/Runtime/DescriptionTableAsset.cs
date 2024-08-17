using UGF.Description.Runtime;
using UGF.Tables.Runtime;

namespace UGF.Module.Descriptions.Runtime
{
    public abstract class DescriptionTableAsset : TableAsset
    {
        public IDescriptionTable Build()
        {
            return OnBuild();
        }

        protected abstract IDescriptionTable OnBuild();
    }
}
