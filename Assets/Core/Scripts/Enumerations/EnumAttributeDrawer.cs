﻿namespace PierreARNAUDET.Core.Enumerations
{
    #if UNITY_EDITOR
    using UnityEngine;
    using UnityEditor;

    [CustomPropertyDrawer(typeof(EnumAttribute))]
    public class EnumAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
        {
            property.intValue = EditorGUI.MaskField(position, label, property.intValue, property.enumNames);
        }
    }
    #endif
}