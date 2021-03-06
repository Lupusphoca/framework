﻿namespace PierreARNAUDET.Core.Movers
{
    using UnityEngine;
    using UnityEngine.Events;

    public class PositionLerpMover : UMover
    {
        [Header("Data")]
        [SerializeField] Transform transformToMove;
        public Transform TransformToMove { get => transformToMove; set { transformToMove = value; } }
        [SerializeField] Vector3 positionToReach;
        public Vector3 PositionToReach { get => positionToReach; set { positionToReach = value; } }

        [Header("Events")]
        [SerializeField] UnityEvent destinationReached;

        public void SmoothLerpMove (float timer)
        {
            transformToMove.position = Vector3.Lerp(transformToMove.position, positionToReach, timer);
            if (transformToMove.position == positionToReach) { destinationReached.Invoke(); }
        }
    }
}
