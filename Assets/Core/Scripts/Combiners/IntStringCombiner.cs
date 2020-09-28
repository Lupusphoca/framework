namespace PierreARNAUDET.Core.Combiners
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Events;

    public class IntStringCombiner : UCombiner<int, string>
    {
        [Header("Data")]
        [SerializeField] int firstObject;
        public override int FirstObject { get => firstObject; set => firstObject = value; }
        [SerializeField] string secondObject;
        public override string SecondObject { get => secondObject; set => secondObject = value; }

        [Header("Events")]
        [SerializeField] IntStringEvent intStringEvent;
        protected override UnityEvent<int, string> CombinedEvent => intStringEvent;
    }
}