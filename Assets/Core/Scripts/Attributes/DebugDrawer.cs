namespace PierreARNAUDET.Core.Attributes
{
#if UNITY_EDITOR
    using UnityEditor;
    using UnityEngine;

    [CustomPropertyDrawer(typeof(DebugAttribute))]
    public class DebugDrawer : DecoratorDrawer
    {
        public override void OnGUI(Rect position)
        {
            var dataAttribute = (DebugAttribute)attribute;
            var style = new GUIStyle(GUI.skin.label);
            style.fontStyle = FontStyle.Bold;
            style.normal.textColor = Color.white;
            EditorGUI.LabelField(position, dataAttribute.HeaderName, style);
        }
    }
#endif
}