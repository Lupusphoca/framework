namespace PierreARNAUDET.Core.Attributes
{
#if UNITY_EDITOR
    using UnityEditor;
    using UnityEngine;

    [CustomPropertyDrawer(typeof(SettingsAttribute))]
    public class SettingsDrawer : DecoratorDrawer
    {
        public override void OnGUI(Rect position)
        {
            var dataAttribute = (SettingsAttribute)attribute;
            var style = new GUIStyle(GUI.skin.label);
            style.fontStyle = FontStyle.Bold;
            style.normal.textColor = Color.blue;
            EditorGUI.LabelField(position, dataAttribute.HeaderName, style);
        }
    }
#endif
}