namespace PierreARNAUDET.Core.Injectors
{
    using UnityEngine;

    using PierreARNAUDET.Core.Events;

    public class RaycastHitInjector : UInjector<RaycastHit>
    {
        [Header("Data")]
        [SerializeField] RaycastHit raycastHitToInject;
        public override RaycastHit ObjToInject { get => raycastHitToInject; set => raycastHitToInject = value; }

        [Header("Events")]
        [SerializeField] RaycastHitEvent raycastHitEvent;
        [SerializeField] ColliderEvent hitCollider;
        [SerializeField] FloatEvent distance;
        [SerializeField] Vector3Event hitNormalVector;
        [SerializeField] Vector3Event hitPoint;
        [SerializeField] RigidbodyEvent hitRigidbody;
        [SerializeField] TransformEvent hitTransform;

        protected override void InjectObject(RaycastHit obj)
        {
            raycastHitEvent.Invoke(obj);
            hitCollider.Invoke(obj.collider);
            distance.Invoke(obj.distance);
            hitNormalVector.Invoke(obj.normal);
            hitPoint.Invoke(obj.point);
            hitRigidbody.Invoke(obj.rigidbody);
            hitTransform.Invoke(obj.transform);
        }
    }
}
