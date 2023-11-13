using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UnityEditor;
using UnityEngine;

namespace UGF.Module.Descriptions.Editor
{
    [CustomEditor(typeof(DescriptionEditorSettingsData), true)]
    internal class DescriptionEditorSettingsDataEditor : UnityEditor.Editor
    {
        private ReorderableListDrawer m_foldersList;
        private ReorderableListSelectionDrawerByElement m_foldersListSelection;

        private void OnEnable()
        {
            m_foldersList = new ReorderableListDrawer(serializedObject.FindProperty("m_folders"));

            m_foldersListSelection = new ReorderableListSelectionDrawerByElement(m_foldersList)
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_foldersList.Enable();
            m_foldersListSelection.Enable();
        }

        private void OnDisable()
        {
            m_foldersList.Disable();
            m_foldersListSelection.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                m_foldersList.DrawGUILayout();
            }

            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.FlexibleSpace();

                using (new EditorGUI.DisabledScope(m_foldersList.List.selectedIndices.Count == 0))
                {
                    if (GUILayout.Button("Update"))
                    {
                        OnUpdate();
                    }
                }

                using (new EditorGUI.DisabledScope(m_foldersList.SerializedProperty.arraySize == 0))
                {
                    if (GUILayout.Button("Update All"))
                    {
                        OnUpdateAll();
                    }
                }

                EditorGUILayout.Space();
            }

            EditorGUILayout.Space();

            m_foldersListSelection.DrawGUILayout();
        }

        private void OnUpdate()
        {
            foreach (int index in m_foldersList.List.selectedIndices)
            {
                SerializedProperty propertyElement = m_foldersList.SerializedProperty.GetArrayElementAtIndex(index);
                var asset = propertyElement.objectReferenceValue as DescriptionFolderAsset;

                if (asset != null)
                {
                    DescriptionFolderEditorUtility.TryUpdate(asset);
                }
            }
        }

        private void OnUpdateAll()
        {
            DescriptionEditorSettings.TryUpdateAll();
        }
    }
}
