namespace PierreARNAUDET.Modules.DOT.Rigidbodies
{
    using UnityEngine;
    using UnityEngine.Events;

    public abstract class URigidbodyDOT : MonoBehaviour
    {
        public abstract Rigidbody Rigidbody { get; set; }

        public abstract UnityEvent @Event { get; set; }
    }
}