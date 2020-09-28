namespace PierreARNAUDET.Core.Injectors
{
    using UnityEngine;

    using PierreARNAUDET.Core.Events;

    public class Vector2Injector : UInjector<Vector2>
    {
        [Header("Data")]
        [SerializeField] Vector2 vector2ToInject;
        public override Vector2 ObjToInject { get => vector2ToInject; set => vector2ToInject = value; }

        [Header("Events")]
        [SerializeField] Vector2Event vector2Event;
        [SerializeField] FloatEvent magnitudeEvent;
        [SerializeField] Vector2Event normalizedEvent;
        [SerializeField] FloatEvent sqrMagnitudeEvent;
        [SerializeField] FloatEvent xEvent;
        [SerializeField] FloatEvent yEvent;

        protected override void InjectObject(Vector2 obj)
        {
            vector2Event.Invoke(obj);
            magnitudeEvent.Invoke(obj.magnitude);
            normalizedEvent.Invoke(obj.normalized);
            sqrMagnitudeEvent.Invoke(obj.sqrMagnitude);
            xEvent.Invoke(obj.x);
            yEvent.Invoke(obj.y);
        }
    }
}
