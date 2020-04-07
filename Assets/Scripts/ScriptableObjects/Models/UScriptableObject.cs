namespace Core.ScriptableObjects.Models
{
    using UnityEngine;

    public abstract class UScriptableObject<T> : ScriptableObject
    {
        [SerializeField] T value;

        public T Value { get => value; set => this.value = value; }

        public static implicit operator T(UScriptableObject<T> @struct) => @struct.Value;
    }
}