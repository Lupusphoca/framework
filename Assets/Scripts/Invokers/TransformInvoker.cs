namespace Core.Invokers
{
    using UnityEngine;
    using UnityEngine.Events;

    using Core.Events;

    public class TransformInvoker : UInvoker<Transform>
    {
        [Header("Dynamic data")]
        [SerializeField] Transform transform;

        [Header("Flow")]
        [SerializeField] TransformEvent invokedTransform;

        public override Transform Obj { get => transform; set => transform = value; }

        protected override UnityEvent<Transform> InvokedObj => invokedTransform;
    }
}