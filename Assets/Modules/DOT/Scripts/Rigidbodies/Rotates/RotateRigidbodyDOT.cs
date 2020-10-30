namespace PierreARNAUDET.Modules.DOT.Rigidbodies
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class RotateRigidbodyDOT : URigidbodyDOT
    {
        [Data]
        [SerializeField] Rigidbody rigidbody;
        public override Rigidbody Rigidbody { get => rigidbody; set => rigidbody = value; }

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
            rigidbody.DORotate(endValue, duration, mode);
            @event.Invoke();
        }
    }
}