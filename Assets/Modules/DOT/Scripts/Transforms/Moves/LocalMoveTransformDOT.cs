namespace PierreARNAUDET.Modules.DOT.Transforms
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class LocalMoveTransformDOT : UTransformDOT
    {
        [Data]
        [SerializeField] Transform transform;
        public override Transform Transform { get => transform; set => transform = value; }

        [Settings]
        [SerializeField] Vector3 endValue;
        public Vector3 EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] bool snapping;
        public bool Snapping { get => snapping; set => snapping = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOLocalMove(Vector3 newEndValue, float newDuration, bool newSnapping)
        {
            endValue = newEndValue;
            duration = newDuration;
            snapping = newSnapping;
            DOLocalMove();
        }

        public void DOLocalMove()
        {
            transform.DOLocalMove(endValue, duration, snapping);
            @event.Invoke();
        }
    }
}