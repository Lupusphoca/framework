namespace Core.Checkers
{
    using UnityEngine;
    using UnityEngine.Events;

    using Core.Events;

    public class BoolChecker : UChecker<bool>
    {

        [Header("Events")]
        [SerializeField] BoolEvent validBool;
        [SerializeField] BoolEvent invalidBool;

        protected override UnityEvent<bool> ValidObject => validBool;

        protected override UnityEvent<bool> InvalidObject => invalidBool;

        protected override bool CheckObject(bool obj)
        {
            return obj;
        }
    }
}