namespace Core.InOutLinker
{
    using UnityEngine;
    using UnityEngine.Events;

    using Core.Events;

    public class Vector3OutLinker : UOutLinker<Vector3>
    {
        [Header("Dynamic data")]
        [SerializeField] Vector3 data;

        [Header("Events")]
        [SerializeField] Vector3Event vector3Event;

        public override Vector3 Data { get => data; set => data = value; }

        public override UnityEvent<Vector3> unityEvent => vector3Event;
    }
}
