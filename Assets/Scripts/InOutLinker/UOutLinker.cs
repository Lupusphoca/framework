namespace Core.InOutLinker
{
    using UnityEngine.Events;

    public abstract class UOutLinker<T>
    {
        public abstract T Data { get; set; }
        public abstract UnityEvent<T> unityEvent { get; }

        public virtual void Continue(T data)
        {
            Data = data;
            unityEvent.Invoke(data);
        }
    }
}