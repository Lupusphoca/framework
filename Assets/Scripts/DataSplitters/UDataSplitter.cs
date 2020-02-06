namespace Core.DataSplitters
{
    using UnityEngine;
    using UnityEngine.Events;

    public abstract class UDataSplitter<T> : MonoBehaviour
    {
        protected abstract UnityEvent<T> ObjectSplitted { get; }

        public abstract void SplitData(T obj);
    }
}