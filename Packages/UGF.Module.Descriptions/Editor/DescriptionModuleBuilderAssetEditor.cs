using UGF.Application.Editor;
using UGF.Module.Descriptions.Runtime;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace UGF.Module.Descriptions.Editor
{
    [CustomEditor(typeof(DescriptionModuleInfoAsset), true)]
    internal class DescriptionModuleBuilderAssetEditor : ApplicationModuleInfoAssetEditor
    {
        private SerializedProperty m_script;
        private ReorderableList m_list;

        private void OnEnable()
        {
            m_script = serializedObject.FindProperty("m_Script");

            SerializedProperty propertyAssetInfos = serializedObject.FindProperty("m_assets");

            m_list = new ReorderableList(serializedObject, propertyAssetInfos);
            m_list.drawHeaderCallback = OnDrawHeader;
            m_list.drawElementCallback = OnDrawElement;
            m_list.elementHeightCallback = OnElementHeight;
            m_list.onAddCallback = OnAdd;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfRequiredOrScript();

            using (new EditorGUI.DisabledScope(true))
            {
                EditorGUILayout.PropertyField(m_script);
            }

            m_list.DoLayoutList();

            DrawModuleInfo();

            serializedObject.ApplyModifiedProperties();
        }

        private void OnDrawHeader(Rect rect)
        {
            string label = $"Descriptions (Size: {m_list.count})";

            GUI.Label(rect, label, EditorStyles.boldLabel);
        }

        private void OnDrawElement(Rect rect, int index, bool isActive, bool isFocused)
        {
            SerializedProperty propertyElement = m_list.serializedProperty.GetArrayElementAtIndex(index);

            rect.y += EditorGUIUtility.standardVerticalSpacing;
            rect.height = EditorGUIUtility.singleLineHeight;

            EditorGUI.PropertyField(rect, propertyElement, GUIContent.none);
        }

        private float OnElementHeight(int index)
        {
            float spacing = EditorGUIUtility.standardVerticalSpacing;
            float height = EditorGUIUtility.singleLineHeight;

            return height + spacing * 2F;
        }

        private void OnAdd(ReorderableList list)
        {
            SerializedProperty propertyModules = list.serializedProperty;

            propertyModules.InsertArrayElementAtIndex(propertyModules.arraySize);

            SerializedProperty propertyElement = propertyModules.GetArrayElementAtIndex(propertyModules.arraySize - 1);

            propertyElement.stringValue = string.Empty;

            serializedObject.ApplyModifiedProperties();
        }
    }
}
