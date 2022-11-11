using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Descriptions.Runtime;
using UnityEditor;

namespace UGF.Module.Descriptions.Editor
{
    [CustomEditor(typeof(DescriptionGroupAsset), true)]
    internal class DescriptionGroupAssetEditor : UnityEditor.Editor
    {
        private ReorderableListKeyAndValueDrawer m_listDescriptions;
        private ReorderableListDrawer m_listGroups;
        private ReorderableListSelectionDrawerByElement m_listGroupsSelection;

        private void OnEnable()
        {
            m_listDescriptions = new ReorderableListKeyAndValueDrawer(serializedObject.FindProperty("m_descriptions"));

            m_listGroups = new ReorderableListDrawer(serializedObject.FindProperty("m_groups"));

            m_listGroupsSelection = new ReorderableListSelectionDrawerByElement(m_listGroups)
            {
                Drawer =
                {
                    DisplayTitlebar = true
                }
            };

            m_listDescriptions.Enable();
            m_listGroups.Enable();
            m_listGroupsSelection.Enable();
        }

        private void OnDisable()
        {
            m_listDescriptions.Disable();
            m_listGroups.Disable();
            m_listGroupsSelection.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listDescriptions.DrawGUILayout();
                m_listGroups.DrawGUILayout();

                m_listGroupsSelection.DrawGUILayout();
            }
        }
    }
}
