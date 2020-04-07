namespace Core.Injectors
{
    using UnityEngine;
    using UnityEngine.Events;

    [DisallowMultipleComponent]
    public abstract class UInjector<T> : MonoBehaviour
    {
        [Header ("Dynamic data")]
        [SerializeField] T objToInject;

        public virtual T ObjToInject { get => objToInject; set => objToInject = value; } // TODO Set to simple {get;set;} when objToInject is removed

        protected virtual bool AllowNullInjection { get => false; }
        protected virtual UnityEvent<T> ObjectInjected { get => null; }

        public void Inject()
        {
            var isClass = typeof(T).IsClass;
            var isInterface = typeof(T).IsInterface;
            if (AllowNullInjection || ((isClass || isInterface)/* && ObjToInject != default*/))
            {
                InjectObject(ObjToInject);
            }
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