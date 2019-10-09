using System.Collections.Generic;
using UGF.Description.Runtime;

namespace UGF.Module.Descriptions.Runtime
{
    public interface IDescriptionModuleDescription : IDescription
    {
        IReadOnlyList<IDescriptionAssetInfo> AssetInfos { get; }
    }
}
