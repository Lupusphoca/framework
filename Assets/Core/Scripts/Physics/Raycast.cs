namespace PierreARNAUDET.Core.Physics
{
    using UnityEngine;

    using PierreARNAUDET.Core.Events;

    public class Raycast : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] Transform origin;
        public Transform Origin { get => origin; set => origin = value; }
        [SerializeField] Transform target;
        public Transform Target { get => target; set => target = value; }
        [SerializeField] float maxDistance;
        public float MaxDistance { get => maxDistance; set => maxDistance = value; }
        [SerializeField] LayerMask layerMask;
        public LayerMask LayerMask { get => layerMask; set => layerMask = value; }

        [Header("Events : Hit data")]
        [SerializeField] Vector3Event hitBarycentricCoordinate;
        [SerializeField] FloatEvent hitDistance;
        [SerializeField] Vector2Event hitLightmapCoord;
        [SerializeField] Vector3Event hitNormal;
        [SerializeField] Vector3Event hitPoint;
        [SerializeField] RigidbodyEvent hitRigidbody;
        [SerializeField] Vector2Event hitTextureCoord;
        [SerializeField] Vector2Event hitTextureCoord2;
        [SerializeField] TransformEvent hitTransform;
        [SerializeField] IntEvent hitTriangleIndex;
        [SerializeField] ColliderEvent hitCollider;

        [Header("Events : Raycast informations")]
        [SerializeField] Vector3Event initialRaycastPoint;
        [SerializeField] Vector3Event finalRaycastPoint;
        [SerializeField] FloatEvent maxDistanceRaycast;

        public void StartRaycast()
        {
            var distance = target.position - origin.position;
            if (Physics.Raycast(origin.position, distance, out RaycastHit hitInfo, maxDistance, layerMask)) {
                hitBarycentricCoordinate.Invoke(hitInfo.barycentricCoordinate);
                hitDistance.Invoke(hitInfo.distance);
                hitLightmapCoord.Invoke(hitInfo.lightmapCoord);
                hitNormal.Invoke(hitInfo.normal);
                hitPoint.Invoke(hitInfo.point);
                hitRigidbody.Invoke(hitInfo.rigidbody);
                hitTextureCoord.Invoke(hitInfo.textureCoord);
                hitTextureCoord2.Invoke(hitInfo.textureCoord2);
                hitTransform.Invoke(hitInfo.transform);
                hitTriangleIndex.Invoke(hitInfo.triangleIndex);
                hitCollider.Invoke(hitInfo.collider);
            } else
            {
                initialRaycastPoint.Invoke(origin.position);
                finalRaycastPoint.Invoke((distance * maxDistance) + origin.position);
                maxDistanceRaycast.Invoke(maxDistance);
            }
        }
    }
}