using System.Collections.Generic;
using UGF.CustomSettings.Runtime;
using UnityEngine;

namespace UGF.Module.Descriptions.Editor
{
    public class DescriptionEditorSettingsData : CustomSettingsData
    {
        [SerializeField] private bool m_foldersAutoUpdate = true;
        [SerializeField] private List<DescriptionFolderAsset> m_folders = new List<DescriptionFolderAsset>();

        public bool FoldersAutoUpdate { get { return m_foldersAutoUpdate; } set { m_foldersAutoUpdate = value; } }
        public List<DescriptionFolderAsset> Folders { get { return m_folders; } }
    }
}
