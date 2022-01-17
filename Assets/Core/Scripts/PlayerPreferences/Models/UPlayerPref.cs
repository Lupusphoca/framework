namespace PierreARNAUDET.Core.PlayerPreferences.Models
{
    using System;
    using UnityEngine;

    using PierreARNAUDET.Core.Holders.Models;
    using PierreARNAUDET.Core.PlayerPreferences.Helpers;

    public abstract class UPlayerPref<T> : UHolder<T> where T : IEquatable<T>
    {
        [SerializeField] string key;

        string Key
        {
            get
            {
                key = name;
                return key;
            }
        }

        protected override T GetValue() => PlayerPrefsHelper.Get(Key, DefaultValue);

        protected override bool SetValue(T value)
        {
            if (!value.Equals(Value))
            {
                PlayerPrefsHelper.Set(Key, value);
                return true;
            }
            return false;
        }

#if UNITY_EDITOR
        new void Reset() => key = name;
#endif
    }
}