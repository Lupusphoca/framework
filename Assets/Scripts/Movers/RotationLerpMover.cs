namespace Core.Movers
{
    using UnityEngine;
    using UnityEngine.Events;

    public class RotationLerpMover : UMover
    {

        [Header("Dynamic Data")]
        [SerializeField] Transform transformToMove;
        [SerializeField] Quaternion rotationToReach;

        public Transform TransformToMove { get => transformToMove; set { transformToMove = value; } }
        public Quaternion RotationToReach { get => rotationToReach; set { rotationToReach = value; } }

        [Header("Events")]
        [SerializeField] UnityEvent destinationReached;

        public void SmoothLerpMove(float timer)
        {
            transformToMove.rotation = Quaternion.Lerp(transformToMove.rotation, rotationToReach, timer);
            if (transformToMove.rotation == rotationToReach) { destinationReached.Invoke(); }
        }
    }
}
