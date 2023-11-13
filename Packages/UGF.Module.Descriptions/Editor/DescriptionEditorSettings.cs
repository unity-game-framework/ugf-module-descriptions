using System.Collections.Generic;
using UGF.CustomSettings.Editor;
using UnityEditor;

namespace UGF.Module.Descriptions.Editor
{
    public static class DescriptionEditorSettings
    {
        public static CustomSettingsEditorPackage<DescriptionEditorSettingsData> Settings { get; } = new CustomSettingsEditorPackage<DescriptionEditorSettingsData>
        (
            "UGF.Module.Descriptions",
            nameof(DescriptionEditorSettingsData)
        );

        private static readonly Dictionary<string, DescriptionFolderAsset> m_groups = new Dictionary<string, DescriptionFolderAsset>();

        public static bool TryUpdateAll()
        {
            DescriptionEditorSettingsData data = Settings.GetData();
            bool all = true;

            for (int i = 0; i < data.Folders.Count; i++)
            {
                DescriptionFolderAsset asset = data.Folders[i];

                if (!DescriptionFolderEditorUtility.TryUpdate(asset))
                {
                    all = false;
                }
            }

            return all;
        }

        public static IReadOnlyDictionary<string, DescriptionFolderAsset> GetFoldersGroupedByPath()
        {
            DescriptionEditorSettingsData data = Settings.GetData();

            m_groups.Clear();

            DescriptionFolderEditorUtility.GroupByFolderPath(m_groups, data.Folders);

            return m_groups;
        }

        [SettingsProvider]
        private static SettingsProvider GetProvider()
        {
            return new CustomSettingsProvider<DescriptionEditorSettingsData>("Project/Unity Game Framework/Description", Settings, SettingsScope.Project);
        }
    }
}
