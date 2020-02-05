namespace Core.Checkers
{
    using UnityEngine;
    using UnityEngine.Events;

    using Core.Events;

    public class FloatSuperiorFloatChecker : UChecker<float>
    {
        [Header("Dynamic Data")]
        [SerializeField] float floatCompareReference;

        public float FloatCompareReference { get => floatCompareReference; set { floatCompareReference = value; } }

        [Header("Events")]
        [SerializeField] FloatEvent validFloat;
        [SerializeField] FloatEvent invalidFloat;

        protected override UnityEvent<float> ValidObject => validFloat;

        protected override UnityEvent<float> InvalidObject => invalidFloat;

        protected override bool CheckObject(float obj)
        {
            if (obj > floatCompareReference)
            {
                return true;
            }
            return false;
        }
    }
}
