using UGF.Module.Descriptions.Runtime;
using UnityEngine;

namespace UGF.Module.Descriptions.Editor
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Descriptions/Description Folder", order = 2000)]
    public class DescriptionFolderAsset : ScriptableObject
    {
        [SerializeField] private Object m_folder;
        [SerializeField] private DescriptionCollectionAsset m_collection;

        public Object Folder { get { return m_folder; } set { m_folder = value; } }
        public DescriptionCollectionAsset Collection { get { return m_collection; } set { m_collection = value; } }
    }
}
