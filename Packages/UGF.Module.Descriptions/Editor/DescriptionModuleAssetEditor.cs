using UGF.EditorTools.Editor.Assets;
using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Descriptions.Runtime;
using UnityEditor;

namespace UGF.Module.Descriptions.Editor
{
    [CustomEditor(typeof(DescriptionModuleAsset), true)]
    internal class DescriptionModuleAssetEditor : UnityEditor.Editor
    {
        private AssetIdReferenceListDrawer m_listDescriptions;
        private ReorderableListSelectionDrawerByPath m_listDescriptionsSelection;
        private AssetIdReferenceListDrawer m_listCollections;
        private ReorderableListSelectionDrawerByPath m_listCollectionsSelection;

        private void OnEnable()
        {
            m_listDescriptions = new AssetIdReferenceListDrawer(serializedObject.FindProperty("m_descriptions"));

            m_listDescriptionsSelection = new ReorderableListSelectionDrawerByPath(m_listDescriptions, "m_asset")
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listCollections = new AssetIdReferenceListDrawer(serializedObject.FindProperty("m_collections"));

            m_listCollectionsSelection = new ReorderableListSelectionDrawerByPath(m_listCollections, "m_asset")
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listDescriptions.Enable();
            m_listDescriptionsSelection.Enable();
            m_listCollections.Enable();
            m_listCollectionsSelection.Enable();
        }

        private void OnDisable()
        {
            m_listDescriptions.Disable();
            m_listDescriptionsSelection.Enable();
            m_listCollections.Disable();
            m_listCollectionsSelection.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listDescriptions.DrawGUILayout();
                m_listCollections.DrawGUILayout();

                m_listDescriptionsSelection.DrawGUILayout();
                m_listCollectionsSelection.DrawGUILayout();
            }
        }
    }
}
