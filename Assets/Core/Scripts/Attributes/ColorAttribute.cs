namespace PierreARNAUDET.Core.Attributes
{
    using System;

    using UnityEngine;

    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public class ColorAttribute : PropertyAttribute
    {
        public float r, g, b;

        public ColorAttribute(float _r, float _g, float _b)
        {
            r = _r;
            g = _g;
            b = _b;
        }
    }
}