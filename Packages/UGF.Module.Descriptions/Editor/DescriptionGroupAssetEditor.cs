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

        private void OnEnable()
        {
            m_listDescriptions = new ReorderableListKeyAndValueDrawer(serializedObject.FindProperty("m_descriptions"));
            m_listDescriptions.Enable();
        }

        private void OnDisable()
        {
            m_listDescriptions.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listDescriptions.DrawGUILayout();
            }
        }
    }
}
