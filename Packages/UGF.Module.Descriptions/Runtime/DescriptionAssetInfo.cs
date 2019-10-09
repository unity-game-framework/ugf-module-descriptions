using System;
using UnityEngine;

namespace UGF.Module.Descriptions.Runtime
{
    [Serializable]
    public class DescriptionAssetInfo : IDescriptionAssetInfo
    {
        [SerializeField] private string m_registerName;
        [SerializeField] private string m_assetName;

        public string RegisterName { get { return m_registerName; } set { m_registerName = value; } }
        public string AssetName { get { return m_assetName; } set { m_assetName = value; } }
    }
}
