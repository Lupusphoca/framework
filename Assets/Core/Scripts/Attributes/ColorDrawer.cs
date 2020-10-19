namespace PierreARNAUDET.Core.Attributes
{
#if UNITY_EDITOR
    using UnityEditor;
    using UnityEngine;

    [CustomPropertyDrawer(typeof(ColorAttribute))]
    public class ColorDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var colorAttribute = (ColorAttribute)attribute;
            var newColor = new Color(colorAttribute.r, colorAttribute.g, colorAttribute.b);
            GUI.color = newColor;
            EditorGUI.PropertyField(position, property, label);
            GUI.color = Color.white;
        }
    }
#endif
}