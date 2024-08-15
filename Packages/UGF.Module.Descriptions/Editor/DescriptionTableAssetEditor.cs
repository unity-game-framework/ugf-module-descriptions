using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Descriptions.Runtime;
using UnityEditor;

namespace UGF.Module.Descriptions.Editor
{
    [CustomEditor(typeof(DescriptionTableAsset<,>), true)]
    internal class DescriptionTableAssetEditor : UnityEditor.Editor
    {
        private ReorderableListDrawer m_listTables;
        private ReorderableListSelectionDrawerByElement m_listTablesSelection;

        private void OnEnable()
        {
            m_listTables = new ReorderableListDrawer(serializedObject.FindProperty("m_tables"));

            m_listTablesSelection = new ReorderableListSelectionDrawerByElement(m_listTables)
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listTables.Enable();
            m_listTablesSelection.Enable();
        }

        private void OnDisable()
        {
            m_listTables.Disable();
            m_listTablesSelection.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listTables.DrawGUILayout();
                m_listTablesSelection.DrawGUILayout();
            }
        }
    }
}
