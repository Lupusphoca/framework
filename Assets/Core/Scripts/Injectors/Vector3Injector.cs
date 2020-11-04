namespace PierreARNAUDET.Core.Injectors
{
    using UnityEngine;

    using PierreARNAUDET.Core.Events;
    using PierreARNAUDET.Core.Attributes;

    public class Vector3Injector : UInjector<Vector3>
    {
        [Data]
        [SerializeField] Vector3 vector2ToInject;
        public override Vector3 ObjToInject { get => vector2ToInject; set => vector2ToInject = value; }

        [Events]
        [SerializeField] Vector3Event vector3Event;
        [SerializeField] FloatEvent magnitudeEvent;
        [SerializeField] Vector3Event normalizedEvent;
        [SerializeField] FloatEvent sqrMagnitudeEvent;
        [SerializeField] FloatEvent xEvent;
        [SerializeField] FloatEvent yEvent;
        [SerializeField] FloatEvent zEvent;

        protected override void InjectObject(Vector3 obj)
        {
            vector3Event.Invoke(obj);
            magnitudeEvent.Invoke(obj.magnitude);
            normalizedEvent.Invoke(obj.normalized);
            sqrMagnitudeEvent.Invoke(obj.sqrMagnitude);
            xEvent.Invoke(obj.x);
            yEvent.Invoke(obj.y);
            zEvent.Invoke(obj.z);
        }
    }
}
