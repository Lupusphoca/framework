namespace PierreARNAUDET.Core.Pickers
{
    using System.Collections.Generic;

    using UnityEngine;
    using UnityEngine.Events;

    [DisallowMultipleComponent]
    public abstract class UDictionaryPicker<TKey, TValue> : MonoBehaviour
    {
        protected abstract UnityEvent<TValue> PickedObject { get; }

        public void Pick(IReadOnlyDictionary<TKey, TValue> objects) => PickedObject.Invoke(PickObject(objects));

        protected abstract TValue PickObject(IReadOnlyDictionary<TKey, TValue> objects);
    }
}