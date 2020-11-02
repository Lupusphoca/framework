namespace PierreARNAUDET.Modules.DOT.Transforms
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class RotateTransformDOT : UTransformDOT
    {
        [Data]
        [SerializeField] Transform transform;
        public override Transform Transform { get => transform; set => transform = value; }

        [Settings]
        [SerializeField] Vector3 endValue;
        public Vector3 EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] RotateMode mode;
        public RotateMode Mode { get => mode; set => mode = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DORotate(Vector3 newEndValue, float newDuration, RotateMode newMode)
        {
            endValue = newEndValue;
            duration = newDuration;
            mode = newMode;
            DORotate();
        }

        public void DORotate()
        {
            transform.DORotate(endValue, duration, mode);
            @event.Invoke();
        }
    }
}