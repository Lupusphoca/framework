﻿namespace PierreARNAUDET.Modules.DOT.Rigidbodies
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class MoveZRigidbodyDOT : URigidbodyDOT
    {
        [Data]
        [SerializeField] Rigidbody rigidbody;
        public override Rigidbody Rigidbody { get => rigidbody; set => rigidbody = value; }

        [Settings]
        [SerializeField] float endValue;
        public float EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] bool snapping;
        public bool Snapping { get => snapping; set => snapping = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOMoveZ(float newEndValue, float newDuration, bool newSnapping)
        {
            endValue = newEndValue;
            duration = newDuration;
            snapping = newSnapping;
            DOMoveZ();
        }

        public void DOMoveZ()
        {
            rigidbody.DOMoveZ(endValue, duration, snapping);
            @event.Invoke();
        }
    }
}