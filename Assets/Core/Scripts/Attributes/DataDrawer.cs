namespace PierreARNAUDET.Core.Attributes
{
#if UNITY_EDITOR
    using UnityEditor;
    using UnityEngine;

    [CustomPropertyDrawer(typeof(DataAttribute))]
    public class DataDrawer : DecoratorDrawer
    {
        public override void OnGUI(Rect position)
        {
            var dataAttribute = (DataAttribute)attribute;
            var style = new GUIStyle(GUI.skin.label);
            style.fontStyle = FontStyle.Bold;
            style.normal.textColor = Color.red;
            EditorGUI.LabelField(position, dataAttribute.HeaderName, style);
        }
    }
#endif
}