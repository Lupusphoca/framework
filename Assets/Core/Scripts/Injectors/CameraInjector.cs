namespace PierreARNAUDET.Core.Injectors
{
    using UnityEngine;

    using PierreARNAUDET.Core.Events;

    public class CameraInjector : UInjector<Camera>
    {
        [Header("Data")]
        [SerializeField] Camera cameraToInject;
        public override Camera ObjToInject { get => cameraToInject; set => cameraToInject = value; }

        [Header("Events")]
        [SerializeField] FloatEvent orthographicSizeEvent;


        protected override void InjectObject(Camera obj)
        {
            orthographicSizeEvent.Invoke(obj.orthographicSize);
        }
    }
}