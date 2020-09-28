namespace PierreARNAUDET.Baseball.ScriptableObjects.Injectors
{
    using UnityEngine;

    using PierreARNAUDET.Core.Events;
    using PierreARNAUDET.Core.Injectors;

    public class DebugInjector : UInjector<Models.Debug>
    {
        [Header("Data")]
        [SerializeField] Models.Debug debugToInject;
        public override Models.Debug ObjToInject { get => debugToInject; set => debugToInject = value; }

        [Header("Events")]
        [SerializeField] FloatEvent distanceEvent;
        [SerializeField] FloatEvent velocityEvent;
        [SerializeField] Vector2Event worldPositionEvent;

        protected override void InjectObject(Models.Debug obj)
        {
            distanceEvent.Invoke(obj.Distance);
            velocityEvent.Invoke(obj.Velocity);
            worldPositionEvent.Invoke(obj.WorldPosition);
        }
    }
}