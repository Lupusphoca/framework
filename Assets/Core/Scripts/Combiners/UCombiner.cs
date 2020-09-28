namespace PierreARNAUDET.Core.Combiners
{
    using UnityEngine;
    using UnityEngine.Events;

    [DisallowMultipleComponent]
    public abstract class UCombiner<T, U> : MonoBehaviour, ICombiner
    {
        public abstract T FirstObject { get; set; }
        public abstract U SecondObject { get; set; }

        protected abstract UnityEvent<T, U> CombinedEvent { get; }

        public void Combine()
        {
            if (FirstObject != null && SecondObject != null)
            {
                CombinedEvent.Invoke(FirstObject, SecondObject);
            }
        }
    }
}