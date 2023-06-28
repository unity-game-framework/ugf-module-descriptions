using UGF.EditorTools.Editor.Ids;
using UGF.EditorTools.Editor.IMGUI;
using UGF.Module.Descriptions.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.Module.Descriptions.Editor
{
    internal class DescriptionGroupDescriptionsListDrawer : ReorderableListKeyAndValueDrawer
    {
        public DescriptionGroupDescriptionsListDrawer(SerializedProperty serializedProperty) : base(serializedProperty)
        {
        }

        protected override bool OnDragAndDropValidate(Object target, out Object result)
        {
            result = target;
            return target is DescriptionAsset;
        }

        protected override void OnDragAndDropAccept(Object target)
        {
            SerializedProperty.InsertArrayElementAtIndex(SerializedProperty.arraySize);

            SerializedProperty propertyElement = SerializedProperty.GetArrayElementAtIndex(SerializedProperty.arraySize - 1);
            SerializedProperty propertyKey = propertyElement.FindPropertyRelative("m_key");
            SerializedProperty propertyValue = propertyElement.FindPropertyRelative("m_value");

            GlobalIdEditorUtility.SetAssetToProperty(propertyKey, target);
            GlobalIdEditorUtility.SetAssetToProperty(propertyValue, target);
        }
    }
}
