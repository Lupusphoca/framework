namespace PierreARNAUDET.Core.Invokers
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Events;

    public class FloatInvoker : UInvoker<float>
    {
        [Header("Data")]
        [SerializeField] float @float;
        public override float Obj { get => @float; set => @float = value; }

        [Header("Events")]
        [SerializeField] FloatEvent floatEvent;
        protected override UnityEvent<float> InvokedObj => floatEvent;
    }
}