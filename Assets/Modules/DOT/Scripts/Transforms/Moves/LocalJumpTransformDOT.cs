﻿namespace PierreARNAUDET.Modules.DOT.Transforms
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class LocalJumpTransformDOT : UTransformDOT
    {
        [Data]
        [SerializeField] Transform transform;
        public override Transform Transform { get => transform; set => transform = value; }

        [Settings]
        [SerializeField] Vector3 endValue;
        public Vector3 EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float jumpPower;
        public float JumpPower { get => jumpPower; set => jumpPower = value; }
        [SerializeField] int numJumps;
        public int NumJumps { get => numJumps; set => numJumps = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] bool snapping;
        public bool Snapping { get => snapping; set => snapping = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOLocalJump(Vector3 newEndValue, float newJumpPower, int newNumJumps, float newDuration, bool newSnapping)
        {
            endValue = newEndValue;
            jumpPower = newJumpPower;
            numJumps = newNumJumps;
            duration = newDuration;
            snapping = newSnapping;
            DOLocalJump();
        }

        public void DOLocalJump()
        {
            transform.DOLocalJump(endValue, jumpPower, numJumps, duration, snapping);
            @event.Invoke();
        }
    }
}