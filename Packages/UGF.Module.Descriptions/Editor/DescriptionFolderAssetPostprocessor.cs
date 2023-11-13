﻿using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace UGF.Module.Descriptions.Editor
{
    internal class DescriptionFolderAssetPostprocessor : AssetPostprocessor
    {
        private static readonly HashSet<string> m_paths = new HashSet<string>();

        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            GetDirectoryPaths(m_paths, importedAssets);
            GetDirectoryPaths(m_paths, deletedAssets);
            GetDirectoryPaths(m_paths, movedAssets);
            GetDirectoryPaths(m_paths, movedFromAssetPaths);

            if (m_paths.Count > 0)
            {
                IReadOnlyDictionary<string, DescriptionFolderAsset> folders = DescriptionEditorSettings.GetFoldersGroupedByPath();

                foreach (string path in m_paths)
                {
                    if (folders.TryGetValue(path, out DescriptionFolderAsset asset))
                    {
                        if (!DescriptionFolderEditorUtility.TryUpdate(asset))
                        {
                            Debug.LogWarning($"Description folder asset update failed: '{path}'.");
                        }
                    }
                }

                m_paths.Clear();

                AssetDatabase.SaveAssets();
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