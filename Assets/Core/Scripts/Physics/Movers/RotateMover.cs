namespace PierreARNAUDET.Core.Movers
{
    using UnityEngine;

    using PierreARNAUDET.Core.Attributes;

    public class RotateMover : UMover
    {
        [Data]
        [SerializeField] Transform transformToMove;
        public Transform TransformToMove { get => transformToMove; set => transformToMove = value; }

        [Settings]
        [SerializeField] bool automaticFixedUpdate;
        [SerializeField] bool automaticUpdate;
        [SerializeField] bool randomRotation;
        [SerializeField, ConditionalHide("randomRotation", true, true)] Vector3 rotationToApply;
        public Vector3 RotationToApply { get => rotationToApply; set => rotationToApply = value; }
        [SerializeField, ConditionalHide("randomRotation", true, false)] float maxRandomRange;

        Vector3 rotation;

        private void Awake()
        {
            if (randomRotation)
            {
                rotation = new Vector3(
                    Random.Range(-maxRandomRange, maxRandomRange),
                    Random.Range(-maxRandomRange, maxRandomRange),
                    Random.Range(-maxRandomRange, maxRandomRange)
                    );
            }
            else
            {
                rotation = rotationToApply;
            }
        }

        private void Update()
        {
            if (automaticUpdate)
            {
                Rotate();
            }
        }

        private void FixedUpdate()
        {
            if (automaticFixedUpdate)
            {
                Rotate();
            }
        }

        public void Rotate()
        {
            transformToMove.Rotate(rotation);
        }
    }
}
