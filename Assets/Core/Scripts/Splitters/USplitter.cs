namespace PierreARNAUDET.Core.Splitters
{
    using System.Collections.Generic;

    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Extensions;

    [DisallowMultipleComponent]
    public abstract class USplitter<T> : MonoBehaviour
    {
        protected abstract UnityEvent<T> Object { get; }

        public void Split(IEnumerable<T> objects) => objects.ForEach(Object.Invoke);
    }
}