using System.Collections.Generic;
using UGF.CustomSettings.Runtime;
using UnityEngine;

namespace UGF.Module.Descriptions.Editor
{
    public class DescriptionEditorSettingsData : CustomSettingsData
    {
        [SerializeField] private List<DescriptionFolderAsset> m_folders = new List<DescriptionFolderAsset>();

        public List<DescriptionFolderAsset> Folders { get { return m_folders; } }
    }
}
