using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace UGF.Module.Descriptions.Runtime
{
    [Serializable]
    public class DescriptionModuleDescription : IDescriptionModuleDescription
    {
        [SerializeField] private List<DescriptionAssetInfo> m_assetInfos = new List<DescriptionAssetInfo>();

        public List<DescriptionAssetInfo> AssetInfos { get { return m_assetInfos; } }

        IReadOnlyList<IDescriptionAssetInfo> IDescriptionModuleDescription.AssetInfos { get { return m_assetInfosReadOnly; } }

        private readonly ReadOnlyCollection<DescriptionAssetInfo> m_assetInfosReadOnly;

        public DescriptionModuleDescription()
        {
            m_assetInfosReadOnly = new ReadOnlyCollection<DescriptionAssetInfo>(m_assetInfos);
        }
    }
}
