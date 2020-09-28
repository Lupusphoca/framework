namespace PierreARNAUDET.Core.Injectors
{
    using UnityEngine;
    using UnityEngine.Events;

    [DisallowMultipleComponent]
    public abstract class UInjector<T> : MonoBehaviour
    {
        public abstract T ObjToInject { get; set; }

        protected virtual bool AllowNullInjection { get => false; }
        protected virtual UnityEvent<T> ObjectInjected { get => null; }

        public void Inject()
        {
            /*var isClass = typeof(T).IsClass;
            var isInterface = typeof(T).IsInterface;
            var isPrimitive = typeof(T).IsPrimitive;
            if (AllowNullInjection || isClass || isInterface || isPrimitive)
            {
                InjectObject(ObjToInject);
            }*/
            //TODO Find a way to allow Unity Classes as available type : isUnityClass ?
            InjectObject(ObjToInject);
            ObjectInjected?.Invoke(ObjToInject);
        }

        public void Inject(T obj)
        {
            ObjToInject = obj;
            Inject();
        }

        protected abstract void InjectObject(T obj);
    }
}