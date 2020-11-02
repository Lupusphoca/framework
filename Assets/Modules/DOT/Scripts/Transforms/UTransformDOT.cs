namespace PierreARNAUDET.Modules.DOT.Transforms
{
    using UnityEngine;
    using UnityEngine.Events;

    public abstract class UTransformDOT : MonoBehaviour
    {
        public abstract Transform Transform { get; set; }

        public abstract UnityEvent @Event { get; set; }
    }
}