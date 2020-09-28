namespace PierreARNAUDET.Core.Invokers
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Events;

    public class Vector3Invoker : UInvoker<Vector3>
    {
        [Header("Data")]
        [SerializeField] Vector3 vector3;
        public override Vector3 Obj { get => vector3; set => vector3 = value; }

        [Header("Events")]
        [SerializeField] Vector3Event vector3Event;
        protected override UnityEvent<Vector3> InvokedObj => vector3Event;
    }
}