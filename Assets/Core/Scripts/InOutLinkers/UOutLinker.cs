namespace PierreARNAUDET.Core.InOutLinker
{
    using UnityEngine;
    using UnityEngine.Events;

    public abstract class UOutLinker<T> : MonoBehaviour, ILinker<T>
    {
        public abstract T Data { get; set; }
        public abstract UnityEvent<T> unityEvent { get; }

        public void Continue(T data)
        {
            Data = data;
            unityEvent.Invoke(data);
        }
    }
}