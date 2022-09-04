namespace PierreARNAUDET.Modules.DOT.Rigidbodies2D
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;
    using System.Collections.Generic;

    public class PathRigidbody2DDOT : URigidbody2DDOT
    {
        [Data]
        [SerializeField] Rigidbody2D _rigidbody2D;
        public override Rigidbody2D Rigidbody2D { get => _rigidbody2D; set => _rigidbody2D = value; }

        [Settings]
        [SerializeField] List<Vector2> waypoints;
        public List<Vector2> Waypoints { get => waypoints; set => waypoints = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] PathType pathType;
        public PathType PathType { get => pathType; set => pathType = value; }
        [SerializeField] PathMode pathMode;
        public PathMode PathMode { get => pathMode; set => pathMode = value; }
        [SerializeField] int resolution;
        public int Resolution { get => resolution; set => resolution = value; }
        [SerializeField] Color gizmoColor;
        public Color GizmoColor { get => gizmoColor; set => gizmoColor = value; }

        [Events]
        [SerializeField] UnityEvent _event;
        public override UnityEvent Event { get => _event; set => _event = value; }

        public void DOPath(List<Vector2> newWaypoints, float newDuration, PathType newPathType, PathMode newPathMode, int newResolution, Color newGizmoColor)
        {
            waypoints = newWaypoints;
            duration = newDuration;
            pathType = newPathType;
            pathMode = newPathMode;
            resolution = newResolution;
            gizmoColor = newGizmoColor;
            DOPath();
        }

        public void DOPath()
        {
            var newWaypoints = waypoints.ToArray();
            _rigidbody2D.DOPath(newWaypoints, duration, pathType, pathMode, resolution, gizmoColor);
            _event.Invoke();
        }
    }
}