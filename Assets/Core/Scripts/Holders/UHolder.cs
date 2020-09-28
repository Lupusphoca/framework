namespace PierreARNAUDET.Core.Holders.Models
{
    using System;
    using UnityEngine;

    public abstract class UHolder<T> : ScriptableObject, IHolder, IEquatable<UHolder<T>>
    {

        [SerializeField] T defaultValue;

        public T DefaultValue => defaultValue;
        object IHolder.DefaultValue => DefaultValue;

        public T Value
        {
            get => GetValue();
            set
            {
                if (SetValue(value))
                {
                    OnValueChanged?.Invoke(value);
                }
            }
        }
        object IHolder.Value => Value;

        public event Action<T> OnValueChanged;

        protected abstract T GetValue();
        protected abstract bool SetValue(T value);

        public void Reinitialize() => Value = DefaultValue;
        [System.Obsolete("Use Reinitialize instead")]
        public void Reset() => Reinitialize();

        public bool Equals(UHolder<T> holder)
        {
            var res = holder != null;
            if (typeof(T).IsAssignableFrom(typeof(IEquatable<T>)))
            {
                res &= holder.Value.Equals(Value);
            }
            else
            {
                res &= ReferenceEquals(Value, holder.Value);
            }
            return res;
        }
    }
}