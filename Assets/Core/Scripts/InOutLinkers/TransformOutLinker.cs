namespace PierreARNAUDET.Core.InOutLinker
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Events;

    public class TransformOutLinker : UOutLinker<Transform>
    {
        [Header("Dynamic data")]
        [SerializeField] Transform data;

        [Header("Events")]
        [SerializeField] TransformEvent transformEvent;

        public override Transform Data { get => data; set => data = value; }

        public override UnityEvent<Transform> unityEvent => transformEvent;
    }
}
