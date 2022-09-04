namespace PierreARNAUDET.Modules.DOT.Rigidbodies2D
{
    using UnityEngine;
    using UnityEngine.Events;

    public abstract class URigidbody2DDOT : MonoBehaviour
    {
        public abstract Rigidbody2D Rigidbody2D { get; set; }

        public abstract UnityEvent Event { get; set; }
    }
}