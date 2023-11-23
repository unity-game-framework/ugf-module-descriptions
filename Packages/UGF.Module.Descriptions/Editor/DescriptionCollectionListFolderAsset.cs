using UGF.Assets.Editor;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UGF.Module.Descriptions.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.Module.Descriptions.Editor
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Descriptions/Description Collection List Folder", order = 2000)]
    public class DescriptionCollectionListFolderAsset : AssetFolderAsset<DescriptionCollectionListAsset, DescriptionAsset>
    {
        protected override void OnUpdate()
        {
            Collection.Descriptions.Clear();

            string[] guids = FindAssetsAsGuids();

            for (int i = 0; i < guids.Length; i++)
            {
                string guid = guids[i];
                string path = AssetDatabase.GUIDToAssetPath(guid);

                var id = new GlobalId(guid);
                var asset = AssetDatabase.LoadAssetAtPath<DescriptionAsset>(path);

                Collection.Descriptions.Add(new AssetIdReference<DescriptionAsset>(id, asset));
            }

            EditorUtility.SetDirty(Collection);
        }
    }
}
