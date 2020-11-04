namespace PierreARNAUDET.Core.Checkers
{
    using UnityEngine;
    using UnityEngine.Events;

    using Core.Events;
    using PierreARNAUDET.Core.Attributes;

    public class FloatInferiorChecker : UChecker<float>
    {
        [Data]
        [SerializeField] float floatReference;
        public float FloatReference { get => floatReference; set { floatReference = value; } }

        [Events]
        [SerializeField] FloatEvent validFloat;
        protected override UnityEvent<float> ValidObject => validFloat;
        [SerializeField] FloatEvent invalidFloat;
        protected override UnityEvent<float> InvalidObject => invalidFloat;

        protected override bool CheckObject(float obj)
        {
            if (obj < floatReference)
            {
                return true;
            }
            return false;
        }
    }
}
