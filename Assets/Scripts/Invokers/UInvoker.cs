namespace Core.Invokers
{
    using UnityEngine;
    using UnityEngine.Events;

    [DisallowMultipleComponent]
    public abstract class UInvoker<T> : MonoBehaviour
    {
        protected virtual bool AllowNullInvocation { get => false; }

        public abstract T Obj { get; set; }
        protected abstract UnityEvent<T> InvokedObj { get; }

        public void Invoke()
        {
            InvokedObj.Invoke(Obj);
            var isClass = typeof(T).IsClass;
            /*if (AllowNullInvocation || (isClass && Obj != default) || !isClass)
            {
                InvokedObj.Invoke(Obj);
            }*/
        }

        public void Invoke(T obj)
        {
            Obj = obj;
            Invoke();
        }
    }
}