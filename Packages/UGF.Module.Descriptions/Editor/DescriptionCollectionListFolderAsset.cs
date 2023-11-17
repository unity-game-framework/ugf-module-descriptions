using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UGF.Module.Assets.Editor;
using UGF.Module.Descriptions.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.Module.Descriptions.Editor
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Descriptions/Description Collection List Folder", order = 2000)]
    public class DescriptionCollectionListFolderAsset : AssetFolderAsset<DescriptionAsset>
    {
        [SerializeField] private DescriptionCollectionListAsset m_collection;

        public DescriptionCollectionListAsset Collection { get { return m_collection; } set { m_collection = value; } }

        protected override bool OnIsValid()
        {
            return m_collection != null;
        }

        protected override void OnUpdate()
        {
            m_collection.Descriptions.Clear();

            string[] guids = FindAssetsAsGuids();

            for (int i = 0; i < guids.Length; i++)
            {
                string guid = guids[i];
                string path = AssetDatabase.GUIDToAssetPath(guid);

                var id = new GlobalId(guid);
                var asset = AssetDatabase.LoadAssetAtPath<DescriptionAsset>(path);

                m_collection.Descriptions.Add(new AssetIdReference<DescriptionAsset>(id, asset));
            }

            EditorUtility.SetDirty(m_collection);
        }
    }
}
