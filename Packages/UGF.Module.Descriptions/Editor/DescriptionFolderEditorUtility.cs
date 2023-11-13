using System;
using System.Collections.Generic;
using System.IO;
using UGF.Module.Descriptions.Runtime;
using UnityEditor;

namespace UGF.Module.Descriptions.Editor
{
    public static class DescriptionFolderEditorUtility
    {
        private static readonly string m_folderSearchFilter = $"t:{nameof(DescriptionFolderAsset)}";
        private static readonly string m_descriptionSearchFilter = $"t:{nameof(DescriptionAsset)}";
        private static readonly string[] m_descriptionSearchFolders = new string[1];

        public static bool TryUpdate(DescriptionFolderAsset asset)
        {
            if (asset == null) throw new ArgumentNullException(nameof(asset));

            if (IsValid(asset))
            {
                string folderPath = AssetDatabase.GetAssetPath(asset.Folder);
                string[] guids = FindDescriptionsInFolder(folderPath);

                if (asset.Collection is DescriptionCollectionListAsset list)
                {
                    list.Descriptions.Clear();

                    DescriptionCollectionListEditorUtility.AddFromGuids(list, guids);
                    EditorUtility.SetDirty(list);
                }

                return true;
            }

            return false;
        }

        public static string[] FindDescriptionsInFolder(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Value cannot be null or empty.", nameof(path));

            m_descriptionSearchFolders[0] = path;

            string[] guids = AssetDatabase.FindAssets(m_descriptionSearchFilter, m_descriptionSearchFolders);

            m_descriptionSearchFolders[0] = null;

            return guids;
        }

        public static bool IsValid(DescriptionFolderAsset asset)
        {
            if (asset == null) throw new ArgumentNullException(nameof(asset));

            if (asset.Folder != null && asset.Collection != null)
            {
                string folderPath = AssetDatabase.GetAssetPath(asset.Folder);

                if (AssetDatabase.IsValidFolder(folderPath))
                {
                    string collectionPath = AssetDatabase.GetAssetPath(asset.Collection);
                    string collectionDirectory = Path.GetDirectoryName(collectionPath);

                    if (!string.IsNullOrEmpty(collectionDirectory))
                    {
                        collectionDirectory = collectionDirectory.Replace('\\', '/');

                        return collectionDirectory != folderPath;
                    }
                }
            }

            return false;
        }

        public static Dictionary<string, DescriptionFolderAsset> GroupByFolderPath(IReadOnlyList<DescriptionFolderAsset> assets)
        {
            var groups = new Dictionary<string, DescriptionFolderAsset>();

            GroupByFolderPath(groups, assets);

            return groups;
        }

        public static void GroupByFolderPath(IDictionary<string, DescriptionFolderAsset> groups, IReadOnlyList<DescriptionFolderAsset> assets)
        {
            if (groups == null) throw new ArgumentNullException(nameof(groups));
            if (assets == null) throw new ArgumentNullException(nameof(assets));

            for (int i = 0; i < assets.Count; i++)
            {
                DescriptionFolderAsset asset = assets[i];
                string path = AssetDatabase.GetAssetPath(asset.Folder);

                if (!AssetDatabase.IsValidFolder(path))
                {
                    throw new ArgumentException($"Description folder has invalid target folder specified: '{asset}'.");
                }

                groups.Add(path, asset);
            }
        }

        public static List<DescriptionFolderAsset> FindAll()
        {
            var assets = new List<DescriptionFolderAsset>();

            FindAll(assets);

            return assets;
        }

        public static void FindAll(ICollection<DescriptionFolderAsset> assets)
        {
            if (assets == null) throw new ArgumentNullException(nameof(assets));

            string[] guids = AssetDatabase.FindAssets(m_folderSearchFilter);

            for (int i = 0; i < guids.Length; i++)
            {
                string guid = guids[i];
                string path = AssetDatabase.GUIDToAssetPath(guid);
                var asset = AssetDatabase.LoadAssetAtPath<DescriptionFolderAsset>(path);

                assets.Add(asset);
            }
        }
    }
}
