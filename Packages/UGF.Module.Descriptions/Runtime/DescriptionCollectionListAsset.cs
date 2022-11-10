using System.Collections.Generic;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Module.Descriptions.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Descriptions/Description Collection List", order = 2000)]
    public class DescriptionCollectionListAsset : DescriptionCollectionAsset
    {
        [SerializeField] private List<AssetIdReference<DescriptionAsset>> m_descriptions = new List<AssetIdReference<DescriptionAsset>>();

        public List<AssetIdReference<DescriptionAsset>> Descriptions { get { return m_descriptions; } }

        protected override void OnGetDescriptions(IDictionary<GlobalId, IDescription> descriptions)
        {
            for (int i = 0; i < m_descriptions.Count; i++)
            {
                AssetIdReference<DescriptionAsset> reference = m_descriptions[i];

                descriptions.Add(reference.Guid, reference.Asset.Build());
            }
        }
    }
}
