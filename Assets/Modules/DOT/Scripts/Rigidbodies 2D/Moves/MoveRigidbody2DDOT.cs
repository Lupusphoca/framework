namespace PierreARNAUDET.Modules.DOT.Rigidbodies2D
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class MoveRigidbody2DDOT : URigidbody2DDOT
    {
        [Data]
        [SerializeField] Rigidbody2D _rigidbody2D;
        public override Rigidbody2D Rigidbody2D { get => _rigidbody2D; set => _rigidbody2D = value; }

        [Settings]
        [SerializeField] Vector2 endValue;
        public Vector2 EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] bool snapping;
        public bool Snapping { get => snapping; set => snapping = value; }

        [Events]
        [SerializeField] UnityEvent _event;
        public override UnityEvent Event { get => _event; set => _event = value; }

        public void DOMove(Vector2 newEndValue, float newDuration, bool newSnapping)
        {
            endValue = newEndValue;
            duration = newDuration;
            snapping = newSnapping;
            DOMove();
        }

        public void DOMove()
        {
            _rigidbody2D.DOMove(endValue, duration, snapping);
            _event.Invoke();
        }
    }
}