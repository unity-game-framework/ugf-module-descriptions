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
        private ReorderableListSelectionDrawerByPathGlobalId m_listDescriptionsSelectionKey;
        private ReorderableListSelectionDrawerByPathGlobalId m_listDescriptionsSelectionValue;
        private ReorderableListDrawer m_listGroups;
        private ReorderableListSelectionDrawerByElement m_listGroupsSelection;

        private void OnEnable()
        {
            m_listDescriptions = new ReorderableListKeyAndValueDrawer(serializedObject.FindProperty("m_descriptions"));

            m_listDescriptionsSelectionKey = new ReorderableListSelectionDrawerByPathGlobalId(m_listDescriptions, "m_key")
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listDescriptionsSelectionValue = new ReorderableListSelectionDrawerByPathGlobalId(m_listDescriptions, "m_value")
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listGroups = new ReorderableListDrawer(serializedObject.FindProperty("m_groups"));

            m_listGroupsSelection = new ReorderableListSelectionDrawerByElement(m_listGroups)
            {
                Drawer =
                {
                    DisplayTitlebar = true
                }
            };

            m_listDescriptions.Enable();
            m_listDescriptionsSelectionKey.Enable();
            m_listDescriptionsSelectionValue.Enable();
            m_listGroups.Enable();
            m_listGroupsSelection.Enable();
        }

        private void OnDisable()
        {
            m_listDescriptions.Disable();
            m_listDescriptionsSelectionKey.Disable();
            m_listDescriptionsSelectionValue.Disable();
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

                m_listDescriptionsSelectionKey.DrawGUILayout();
                m_listDescriptionsSelectionValue.DrawGUILayout();
                m_listGroupsSelection.DrawGUILayout();
            }
        }
    }
}
