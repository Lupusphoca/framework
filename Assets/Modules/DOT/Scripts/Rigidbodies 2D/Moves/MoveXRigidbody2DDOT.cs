namespace PierreARNAUDET.Modules.DOT.Rigidbodies2D
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class MoveXRigidbody2DDOT : URigidbody2DDOT
    {
        [Data]
        [SerializeField] Rigidbody2D rigidbody2D;
        public override Rigidbody2D Rigidbody2D { get => rigidbody2D; set => rigidbody2D = value; }

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

        public void DOMoveX(float newEndValue, float newDuration, bool newSnapping)
        {
            endValue = newEndValue;
            duration = newDuration;
            snapping = newSnapping;
            DOMoveX();
        }

        public void DOMoveX()
        {
            rigidbody2D.DOMoveX(endValue, duration, snapping);
            @event.Invoke();
        }
    }
}