namespace Core.Converters
{
    using UnityEngine;
    using UnityEngine.Events;

    [DisallowMultipleComponent]
    public abstract class UConverter<TIn, TOut> : MonoBehaviour
    {
        protected abstract UnityEvent<TOut> ObjectConverted {get;}

        public void Convert(TIn obj) => ObjectConverted.Invoke (ConvertObject(obj));

        protected abstract TOut ConvertObject (TIn obj);
    }
}