namespace PierreARNAUDET.Core.Invokers
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Events;

    public class QuaternionInvoker : UInvoker<Quaternion>
    {
        [Header("Data")]
        [SerializeField] Quaternion quaternion;
        public override Quaternion Obj { get => quaternion; set => quaternion = value; }

        [Header("Events")]
        [SerializeField] QuaternionEvent quaternionEvent;
        protected override UnityEvent<Quaternion> InvokedObj => quaternionEvent;
    }
}