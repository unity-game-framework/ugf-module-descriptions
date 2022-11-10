using UGF.EditorTools.Editor.Assets;
using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Descriptions.Runtime;
using UnityEditor;

namespace UGF.Module.Descriptions.Editor
{
    [CustomEditor(typeof(DescriptionCollectionListAsset), true)]
    internal class DescriptionCollectionListAssetEditor : UnityEditor.Editor
    {
        private AssetIdReferenceListDrawer m_listDescriptions;
        private ReorderableListSelectionDrawerByPath m_listDescriptionsSelection;

        private void OnEnable()
        {
            m_listDescriptions = new AssetIdReferenceListDrawer(serializedObject.FindProperty("m_descriptions"));

            m_listDescriptionsSelection = new ReorderableListSelectionDrawerByPath(m_listDescriptions, "m_asset")
            {
                Drawer =
                {
                    DisplayTitlebar = true
                }
            };

            m_listDescriptions.Enable();
            m_listDescriptionsSelection.Enable();
        }

        private void OnDisable()
        {
            m_listDescriptions.Disable();
            m_listDescriptionsSelection.Enable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listDescriptions.DrawGUILayout();
                m_listDescriptionsSelection.DrawGUILayout();
            }
        }
    }
}
