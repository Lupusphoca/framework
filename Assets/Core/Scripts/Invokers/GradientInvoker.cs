namespace PierreARNAUDET.Core.Invokers
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Events;

    public class GradientInvoker : UInvoker<Gradient>
    {
        [Header("Data")]
        [SerializeField] Gradient gradient;
        public override Gradient Obj { get => gradient; set => gradient = value; }

        [Header("Events")]
        [SerializeField] GradientEvent gradientEvent;
        protected override UnityEvent<Gradient> InvokedObj => gradientEvent;
    }
}