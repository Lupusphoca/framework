namespace PierreARNAUDET.Core.Pickers
{
    using System.Linq;
    using System.Collections.Generic;

    using UnityEngine;
    using UnityEngine.Events;

    [DisallowMultipleComponent]
    public abstract class UPicker<T> : MonoBehaviour
    {
        protected virtual T DefaultIfEmpty { get => default; }
        protected abstract UnityEvent<T> PickedObject { get; }

        public void Pick(IEnumerable<T> objects)
        {
            var pickedObject = DefaultIfEmpty;
            if (objects.Any())
            {
                pickedObject = PickObject(objects);
            }
            PickedObject.Invoke(pickedObject);
        }

        protected abstract T PickObject(IEnumerable<T> objects);
    }
}