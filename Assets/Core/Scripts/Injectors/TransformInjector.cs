namespace PierreARNAUDET.Core.Injectors
{
    using UnityEngine;

    using PierreARNAUDET.Core.Events;
    using PierreARNAUDET.Core.Attributes;

    public class TransformInjector : UInjector<Transform>
    {
        [Data]
        [SerializeField] Transform transformToInject;
        public override Transform ObjToInject { get => transformToInject; set => transformToInject = value; }

        [Events]
        [SerializeField] TransformEvent transformEvent;
        [SerializeField] FloatEvent rotationEulerAngleX;
        [SerializeField] FloatEvent rotationEulerAngleY;
        [SerializeField] FloatEvent rotationEulerAngleZ;

        [SerializeField] Vector3Event worldPosition;
        [SerializeField] FloatEvent worldPositionX;
        [SerializeField] FloatEvent worldPositionY;
        [SerializeField] FloatEvent worldPositionZ;
        [SerializeField] Vector3Event localScale;

        protected override void InjectObject(Transform obj)
        {
            transformEvent.Invoke(obj);
            rotationEulerAngleX.Invoke(obj.eulerAngles.x);
            rotationEulerAngleY.Invoke(obj.eulerAngles.y);
            rotationEulerAngleZ.Invoke(obj.eulerAngles.z);
            worldPosition.Invoke(obj.position);
            worldPositionX.Invoke(obj.position.x);
            worldPositionY.Invoke(obj.position.y);
            worldPositionZ.Invoke(obj.position.z);
            localScale.Invoke(obj.localScale);
        }
    }
}
