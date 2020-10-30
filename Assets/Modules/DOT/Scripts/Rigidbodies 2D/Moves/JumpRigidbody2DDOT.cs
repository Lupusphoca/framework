﻿namespace PierreARNAUDET.Modules.DOT.Rigidbodies2D
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class JumpRigidbody2DDOT : URigidbody2DDOT
    {
        [Data]
        [SerializeField] Rigidbody2D rigidbody2D;
        public override Rigidbody2D Rigidbody2D { get => rigidbody2D; set => rigidbody2D = value; }

        [Settings]
        [SerializeField] Vector2 endValue;
        public Vector2 EndValue { get => endValue; set => endValue = value; }
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

        public void DOJump(Vector2 newEndValue, float newJumpPower, int newNumJumps, float newDuration, bool newSnapping)
        {
            endValue = newEndValue;
            jumpPower = newJumpPower;
            numJumps = newNumJumps;
            duration = newDuration;
            snapping = newSnapping;
            DOJump();
        }

        public void DOJump()
        {
            rigidbody2D.DOJump(endValue, jumpPower, numJumps, duration, snapping);
            @event.Invoke();
        }
    }
}