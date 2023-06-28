using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Module.Descriptions.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Descriptions/Description Module", order = 2000)]
    public class DescriptionModuleAsset : ApplicationModuleAsset<DescriptionModule, DescriptionModuleDescription>
    {
        [SerializeField] private List<AssetIdReference<DescriptionAsset>> m_descriptions = new List<AssetIdReference<DescriptionAsset>>();
        [SerializeField] private List<AssetIdReference<DescriptionCollectionAsset>> m_collections = new List<AssetIdReference<DescriptionCollectionAsset>>();
        [AssetId(typeof(DescriptionAsset))]
        [SerializeField] private List<GlobalId> m_loadAsync = new List<GlobalId>();

        public List<AssetIdReference<DescriptionAsset>> Descriptions { get { return m_descriptions; } }
        public List<AssetIdReference<DescriptionCollectionAsset>> Collections { get { return m_collections; } }
        public List<GlobalId> LoadAsync { get { return m_loadAsync; } }

        protected override IApplicationModuleDescription OnBuildDescription()
        {
            var descriptions = new Dictionary<GlobalId, IDescription>();

            for (int i = 0; i < m_descriptions.Count; i++)
            {
                AssetIdReference<DescriptionAsset> reference = m_descriptions[i];

                descriptions.Add(reference.Guid, reference.Asset.Build());
            }

            for (int i = 0; i < m_collections.Count; i++)
            {
                AssetIdReference<DescriptionCollectionAsset> reference = m_collections[i];

                descriptions.Add(reference.Guid, reference.Asset.Build());

                reference.Asset.GetDescriptions(descriptions);
            }

            return new DescriptionModuleDescription(typeof(IDescriptionModule), descriptions, m_loadAsync.ToArray());
        }

        protected override DescriptionModule OnBuild(DescriptionModuleDescription description, IApplication application)
        {
            return new DescriptionModule(description, application);
        }
    }
}
