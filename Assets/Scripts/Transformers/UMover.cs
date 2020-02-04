namespace Core.Movers
{
    using UnityEngine;

    public abstract class UMover<T> : MonoBehaviour, IMover
    {
        protected abstract T Object {get; set;}

        public abstract void Move();
    }
}