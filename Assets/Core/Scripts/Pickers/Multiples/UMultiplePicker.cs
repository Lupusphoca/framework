namespace PierreARNAUDET.Core.Pickers
{
    using System.Linq;
    using System.Collections.Generic;

    using UnityEngine;
    using UnityEngine.Events;

    [DisallowMultipleComponent]
    public abstract class UMultiplePicker<T> : MonoBehaviour
    {
        protected virtual IEnumerable<T> DefaultObjectsIfEmpty { get => Enumerable.Empty<T>(); }
        protected abstract UnityEvent<IEnumerable<T>> PickedObjects { get; }

        public void Pick(IEnumerable<T> objects)
        {
            var pickedObjects = DefaultObjectsIfEmpty;
            if (objects.Any())
            {
                pickedObjects = PickObjects(objects);
            }
            PickedObjects.Invoke(pickedObjects);
        }

        protected abstract IEnumerable<T> PickObjects(IEnumerable<T> objects);
    }
}