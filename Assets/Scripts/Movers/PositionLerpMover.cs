namespace Core.Movers
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PositionLerpMover : UMover
    {

        [Header("Dynamic Data")]
        [SerializeField] Transform initialTransform;
        [SerializeField] Transform transformToReach;

        public Transform InitialTransform { get => initialTransform; set { initialTransform = value; } }
        public Transform TransformToReach { get => transformToReach; set { transformToReach = value; } }

        public void SmoothLerpMove (float timer)
        {
            initialTransform.position = Vector3.Lerp(initialTransform.position, transformToReach.position, timer);
        }
    }
}
