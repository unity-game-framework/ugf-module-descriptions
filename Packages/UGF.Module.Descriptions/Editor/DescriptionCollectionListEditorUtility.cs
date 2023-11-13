using System;
using System.Collections.Generic;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UGF.Module.Descriptions.Runtime;
using UnityEditor;

namespace UGF.Module.Descriptions.Editor
{
    public static class DescriptionCollectionListEditorUtility
    {
        public static void AddFromGuids(DescriptionCollectionListAsset asset, IReadOnlyList<string> guids)
        {
            if (asset == null) throw new ArgumentNullException(nameof(asset));
            if (guids == null) throw new ArgumentNullException(nameof(guids));

            for (int i = 0; i < guids.Count; i++)
            {
                string guid = guids[i];
                string path = AssetDatabase.GUIDToAssetPath(guid);

                var descriptionId = new GlobalId(guid);
                var descriptionAsset = AssetDatabase.LoadAssetAtPath<DescriptionAsset>(path);
                var descriptionReference = new AssetIdReference<DescriptionAsset>(descriptionId, descriptionAsset);

                asset.Descriptions.Add(descriptionReference);
            }
        }
    }
}
