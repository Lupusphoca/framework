namespace Core.Comparers
{
    using UnityEngine;
    using UnityEngine.Events;

    [DisallowMultipleComponent]
    public abstract class UComparer<T> : MonoBehaviour
    {
        protected abstract UnityEvent<T> CompareFalse {get;}
    }
}