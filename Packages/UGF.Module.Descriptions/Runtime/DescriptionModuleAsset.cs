using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Assets;
using UnityEngine;

namespace UGF.Module.Descriptions.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Descriptions/Description Module", order = 2000)]
    public class DescriptionModuleAsset : ApplicationModuleAsset<DescriptionModule, DescriptionModuleDescription>
    {
        [SerializeField] private List<AssetIdReference<DescriptionAsset>> m_descriptions = new List<AssetIdReference<DescriptionAsset>>();
        [SerializeField] private List<AssetIdReference<DescriptionCollectionAsset>> m_collections = new List<AssetIdReference<DescriptionCollectionAsset>>();

        public List<AssetIdReference<DescriptionAsset>> Descriptions { get { return m_descriptions; } }
        public List<AssetIdReference<DescriptionCollectionAsset>> Collections { get { return m_collections; } }

        protected override IApplicationModuleDescription OnBuildDescription()
        {
            var description = new DescriptionModuleDescription
            {
                RegisterType = typeof(IDescriptionModule)
            };

            for (int i = 0; i < m_descriptions.Count; i++)
            {
                AssetIdReference<DescriptionAsset> reference = m_descriptions[i];

                description.Descriptions.Add(reference.Guid, reference.Asset.Build());
            }

            for (int i = 0; i < m_collections.Count; i++)
            {
                AssetIdReference<DescriptionCollectionAsset> reference = m_collections[i];

                description.Descriptions.Add(reference.Guid, reference.Asset.Build());

                reference.Asset.GetDescriptions(description.Descriptions);
            }

            return description;
        }

        protected override DescriptionModule OnBuild(DescriptionModuleDescription description, IApplication application)
        {
            return new DescriptionModule(description, application);
        }
    }
}
