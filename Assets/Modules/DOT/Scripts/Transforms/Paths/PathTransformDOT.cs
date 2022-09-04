﻿namespace PierreARNAUDET.Modules.DOT.Transforms
{
    using System.Collections.Generic;

    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class PathTransformDOT : UTransformDOT
    {
        [Data]
        [SerializeField] Transform _transform;
        public override Transform Transform { get => _transform; set => _transform = value; }

        [Settings]
        [SerializeField] List<Vector3> waypoints;
        public List<Vector3> Waypoints { get => waypoints; set => waypoints = value; }
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

        public void DOPath(List<Vector3> newWaypoints, float newDuration, PathType newPathType, PathMode newPathMode, int newResolution, Color newGizmoColor)
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
            _transform.DOPath(newWaypoints, duration, pathType, pathMode, resolution, gizmoColor);
            _event.Invoke();
        }
    }
}