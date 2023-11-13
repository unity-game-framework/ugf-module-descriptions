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
