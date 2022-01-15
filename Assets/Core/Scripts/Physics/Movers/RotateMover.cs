namespace PierreARNAUDET.Core.Movers
{
    using UnityEngine;

    public class RotateMover : UMover
    {
        [Header("Data")]
        [SerializeField] Transform transformToMove;
        public Transform TransformToMove { get => transformToMove; set => transformToMove = value; }
        [SerializeField] Vector3 rotationToApply;
        public Vector3 RotationToApply { get => rotationToApply; set => rotationToApply = value; }

        public void Rotate()
        {
            transformToMove.Rotate(rotationToApply);
        }
    }
}
