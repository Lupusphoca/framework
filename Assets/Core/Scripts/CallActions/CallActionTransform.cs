﻿namespace PierreARNAUDET.Core.CallActions
{
    using PierreARNAUDET.Core.Events;
    using UnityEngine;

    public class CallActionTransform : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] Transform target;
        public Transform Target { get => target; set => target = value; }

        #region Positions
        [Header ("Data : Positions")]
        [SerializeField] Transform transformLookingAt;
        public Transform TransformLookingAt { get => transformLookingAt; set => transformLookingAt = value; }

        [Header("Events : Positions")]
        [SerializeField] Vector3Event actualTargetWorldPosition;

        /// <summary>
        /// Set a new position to the transform working on using Vector3
        /// </summary>
        /// <param name="newTransform">Vector3 to copy</param>
        public void SetPosition (Vector3 newPosition)
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
        public void SetPosition (Transform newTransform)
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
    }
}