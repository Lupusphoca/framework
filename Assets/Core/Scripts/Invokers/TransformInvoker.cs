namespace PierreARNAUDET.Core.Invokers
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Events;

    public class TransformInvoker : UInvoker<Transform>
    {
        [Header("Data")]
        [SerializeField] Transform _transform;
        public override Transform Obj { get => _transform; set => _transform = value; }

        [Header("Events")]
        [SerializeField] TransformEvent invokedTransform;
        protected override UnityEvent<Transform> InvokedObj => invokedTransform;
    }
}