namespace PierreARNAUDET.Modules.DOT.Rigidbodies2D
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class RotateRigidbody2DDOT : URigidbody2DDOT
    {
        [Data]
        [SerializeField] Rigidbody2D rigidbody2D;
        public override Rigidbody2D Rigidbody2D { get => rigidbody2D; set => rigidbody2D = value; }

        [Settings]
        [SerializeField] float endValue;
        public float EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DORotate(float newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DORotate();
        }

        public void DORotate()
        {
            rigidbody2D.DORotate(endValue, duration);
            @event.Invoke();
        }
    }
}