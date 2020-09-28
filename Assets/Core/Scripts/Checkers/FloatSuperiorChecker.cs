namespace PierreARNAUDET.Core.Checkers
{
    using UnityEngine;
    using UnityEngine.Events;

    using Core.Events;

    public class FloatSuperiorChecker : UChecker<float>
    {
        [Header("Data")]
        [SerializeField] float floatReference;
        public float FloatReference { get => floatReference; set { floatReference = value; } }

        [Header("Events")]
        [SerializeField] FloatEvent validFloat;
        protected override UnityEvent<float> ValidObject => validFloat;
        [SerializeField] FloatEvent invalidFloat;
        protected override UnityEvent<float> InvalidObject => invalidFloat;

        protected override bool CheckObject(float obj)
        {
            if (obj > floatReference)
            {
                return true;
            }
            return false;
        }
    }
}
