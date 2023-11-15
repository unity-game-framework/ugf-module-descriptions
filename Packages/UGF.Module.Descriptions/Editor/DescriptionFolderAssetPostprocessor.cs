using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace UGF.Module.Descriptions.Editor
{
    internal class DescriptionFolderAssetPostprocessor : AssetPostprocessor
    {
        private static readonly HashSet<string> m_paths = new HashSet<string>();
        private static readonly Dictionary<string, DescriptionFolderAsset> m_folders = new Dictionary<string, DescriptionFolderAsset>();

        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            if (DescriptionEditorSettings.FoldersAutoUpdate)
            {
                GetDirectoryPaths(m_paths, importedAssets);
                GetDirectoryPaths(m_paths, deletedAssets);
                GetDirectoryPaths(m_paths, movedAssets);
                GetDirectoryPaths(m_paths, movedFromAssetPaths);

                if (m_paths.Count > 0)
                {
                    DescriptionFolderEditorUtility.GroupByFolderPath(m_folders, DescriptionEditorSettings.Settings.GetData().Folders);

                    foreach (string path in m_paths)
                    {
                        if (m_folders.TryGetValue(path, out DescriptionFolderAsset asset))
                        {
                            if (!DescriptionFolderEditorUtility.TryUpdate(asset))
                            {
                                Debug.LogWarning($"Description folder asset update failed: '{path}', asset has missing or invalid fields, or target collection inside the specified folder.");
                            }
                        }
                    }

                    m_paths.Clear();
                    m_folders.Clear();

                    AssetDatabase.SaveAssets();
                }
            }
        }

        private static void GetDirectoryPaths(ICollection<string> collection, string[] paths)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (paths == null) throw new ArgumentNullException(nameof(paths));

            for (int i = 0; i < paths.Length; i++)
            {
                string path = paths[i];
                string directoryPath = Path.GetDirectoryName(path);

                if (!string.IsNullOrEmpty(directoryPath))
                {
                    collection.Add(directoryPath.Replace("\\", "/"));
                }
            }
        }
    }
}
