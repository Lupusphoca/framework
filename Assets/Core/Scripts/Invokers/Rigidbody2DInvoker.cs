namespace PierreARNAUDET.Core.Invokers
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Events;

    public class Rigidbody2DInvoker : UInvoker<Rigidbody2D>
    {
        [Header("Data")]
        [SerializeField] Rigidbody2D _rigidbody2D;
        public override Rigidbody2D Obj { get => _rigidbody2D; set => _rigidbody2D = value; }

        [Header("Events")]
        [SerializeField] Rigidbody2DEvent rigidbody2DEvent;
        protected override UnityEvent<Rigidbody2D> InvokedObj => rigidbody2DEvent;
    }
}