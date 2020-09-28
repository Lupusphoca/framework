namespace PierreARNAUDET.Core.Helpers
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Checkers;
    using PierreARNAUDET.Core.Events;

    public class IntSuperiorChecker : UChecker<int>
    {
        [Header("Data")]
        [SerializeField] int intReference;
        public int IntReference { get => intReference; set { intReference = value; } }

        [Header("Events")]
        [SerializeField] IntEvent validInt;
        protected override UnityEvent<int> ValidObject => validInt;
        [SerializeField] IntEvent invalidInt;
        protected override UnityEvent<int> InvalidObject => invalidInt;

        protected override bool CheckObject(int obj)
        {
            if (obj > IntReference) { return true; }
            return false;
        }
    }
}