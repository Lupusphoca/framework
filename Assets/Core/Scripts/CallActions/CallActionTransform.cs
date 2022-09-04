namespace PierreARNAUDET.Core.CallActions
{
    using PierreARNAUDET.Core.Events;
    using UnityEngine;

    public class CallActionTransform : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] Transform target;
        public Transform Target { get => target; set => target = value; }

        #region Positions
        [Header("Data : Positions")]
        [SerializeField] Transform transformLookingAt;
        public Transform TransformLookingAt { get => transformLookingAt; set => transformLookingAt = value; }

        [Header("Events : Positions")]
        [SerializeField] Vector3Event actualTargetWorldPosition;

        /// <summary>
        /// Set a new position to the transform working on using Vector3
        /// </summary>
        /// <param name="newTransform">Vector3 to copy</param>
        public void SetPosition(Vector3 newPosition)
        {
            if (target != null)
            {
                target.position = newPosition;
            }
        }

        /// <summary>
        /// Set a new position to the transform working on using Transform
        /// </summary>
        /// <param name="newTransform">Transform to copy</param>
        public void SetPosition(Transform newTransform)
        {
            if (target != null)
            {
                target.position = newTransform.position;
            }
        }

        /// <summary>
        /// Set a new position to the transform working on using transform already referenced in the object
        /// </summary>
        public void SetPosition()
        {
            if (target != null && transformLookingAt != null)
            {
                target.position = transformLookingAt.position;
            }
        }

        /// <summary>
        /// Call vector3 event that return actual target world position
        /// </summary>
        public void GetWorldPosition()
        {
            actualTargetWorldPosition.Invoke(target.position);
        }
        #endregion

        #region Rotations
        /// <summary>
        /// Set a new world rotation to the transform working on using Vector3
        /// </summary>
        /// <param name="newTransform">Vector3 to copy</param>
        public void SetWorldRotation(Vector3 newRotation)
        {
            if (target != null)
            {
                target.eulerAngles = newRotation;
            }
        }

        /// <summary>
        /// Set a new world rotation to the transform working on using Quaternion
        /// </summary>
        /// <param name="newTransform">Quaternion to copy</param>
        public void SetWorldRotation(Quaternion newRotation)
        {
            if (target != null)
            {
                target.rotation = newRotation;
            }
        }
        #endregion

        #region GetSideVector3
        public enum Side { Up, Right, Forward };

        [Header("Data : Side Vector3")]
        [SerializeField] Side transformSide;
        public Side TransformSide { get => transformSide; set => transformSide = value; }

        [Header("Event : Side Vector3")]
        [SerializeField] Vector3Event choosedVector3Side;

        public void GetSideVector3()
        {
            switch (transformSide)
            {
                case Side.Up:
                    choosedVector3Side.Invoke(target.up);
                    break;
                case Side.Right:
                    choosedVector3Side.Invoke(target.right);
                    break;
                case Side.Forward:
                    choosedVector3Side.Invoke(target.forward);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region RotateTowards
        [Header("Data : Rotate towards")]
        [SerializeField] Transform tranformLookAt;  //* Forward vector will face this object
        public Transform TranformLookAt { get => tranformLookAt; set => tranformLookAt = value; }
        [SerializeField] Vector3 upAxis; //* Up axis is needed as a referenced to move properly the forward vector of the object
        public Vector3 UpAxis { get => upAxis; set => upAxis = value; }

        public void LookAt()
        {
            target.LookAt(tranformLookAt, upAxis);
        }
        #endregion
    }
}