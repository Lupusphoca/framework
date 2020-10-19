namespace PierreARNAUDET.Core.Attributes
{
    using System;

    using UnityEngine;

    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public class SettingsAttribute : PropertyAttribute
    {
        public string HeaderName { get => "Settings"; }
    }
}
