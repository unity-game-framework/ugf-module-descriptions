using System.Collections.Generic;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Assets;
using UnityEngine;

namespace UGF.Module.Descriptions.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Descriptions/Description Group", order = 2000)]
    public class DescriptionGroupAsset : DescriptionAsset
    {
        [SerializeField] private List<AssetIdReference<DescriptionAsset>> m_descriptions = new List<AssetIdReference<DescriptionAsset>>();

        public List<AssetIdReference<DescriptionAsset>> Descriptions { get { return m_descriptions; } }

        protected override IDescription OnBuild()
        {
            var description = new DescriptionGroup();

            for (int i = 0; i < m_descriptions.Count; i++)
            {
                AssetIdReference<DescriptionAsset> reference = m_descriptions[i];

                description.Descriptions.Add(reference.Guid, reference.Asset.Build());
            }

            return description;
        }
    }
}
