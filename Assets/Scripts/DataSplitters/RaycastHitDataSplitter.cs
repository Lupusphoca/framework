namespace Core.DataSplitters
{
    using UnityEngine;
    using UnityEngine.Events;

    using Core.Events;

    public class RaycastHitDataSplitter : UDataSplitter<RaycastHit>
    {
        [Header("Events")]
        [SerializeField] RaycastHitEvent raycastHitEvent;
        [SerializeField] ColliderEvent hitCollider;
        [SerializeField] FloatEvent distance;
        [SerializeField] Vector3Event hitNormalVector;
        [SerializeField] Vector3Event hitPoint;
        [SerializeField] RigidbodyEvent hitRigidbody;
        [SerializeField] TransformEvent hitTransform;

        protected override UnityEvent<RaycastHit> ObjectSplitted => raycastHitEvent;

        public override void SplitData(RaycastHit obj)
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
