namespace PierreARNAUDET.Core.Attributes
{
#if UNITY_EDITOR
    using UnityEditor;
    using UnityEngine;

    [CustomPropertyDrawer(typeof(EventsAttribute))]
    public class EventsDrawer : DecoratorDrawer
    {
        public override void OnGUI(Rect position)
        {
            var dataAttribute = (EventsAttribute)attribute;
            var style = new GUIStyle(GUI.skin.label);
            var color = new Color(0, 0.5f, 0, 1f);
            style.fontStyle = FontStyle.Bold;
            style.normal.textColor = color;
            EditorGUI.LabelField(position, dataAttribute.HeaderName, style);
        }
    }
#endif
}