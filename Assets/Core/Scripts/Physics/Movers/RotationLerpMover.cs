﻿namespace PierreARNAUDET.Core.Movers
{
    using UnityEngine;
    using UnityEngine.Events;

    public class RotationLerpMover : UMover
    {
        [Header("Data")]
        [SerializeField] Transform transformToMove;
        public Transform TransformToMove { get => transformToMove; set { transformToMove = value; } }
        public Quaternion rotationToReach;

        [Header("Events")]
        [SerializeField] UnityEvent destinationReached;

        public void SmoothLerpMove(float timer)
        {
            transformToMove.rotation = Quaternion.Lerp(transformToMove.rotation, rotationToReach, timer);
            var magnitudeToReach = rotationToReach.eulerAngles.magnitude;
            var transformMagnitude = transformToMove.rotation.eulerAngles.magnitude;
            if (Mathf.Approximately(transformMagnitude, magnitudeToReach))
            {
                destinationReached.Invoke();
            }
        }
    }
}
