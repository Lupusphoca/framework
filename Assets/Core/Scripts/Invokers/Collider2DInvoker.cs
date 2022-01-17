namespace PierreARNAUDET.Core.Invokers
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Events;

    public class Collider2DInvoker : UInvoker<Collider2D>
    {
        [Header("Data")]
        [SerializeField] Collider2D _collider2D;
        public override Collider2D Obj { get => _collider2D; set => _collider2D = value; }

        [Header("Events")]
        [SerializeField] Collider2DEvent collider2DEvent;
        protected override UnityEvent<Collider2D> InvokedObj => collider2DEvent;
    }
}