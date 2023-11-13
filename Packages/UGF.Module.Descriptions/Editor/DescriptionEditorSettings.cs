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

        [SettingsProvider]
        private static SettingsProvider GetProvider()
        {
            return new CustomSettingsProvider<DescriptionEditorSettingsData>("Project/Unity Game Framework/Description", Settings, SettingsScope.Project);
        }
    }
}
