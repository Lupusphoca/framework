namespace PierreARNAUDET.Modules.DOT.Rigidbodies
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class RotateRigidbodyDOT : URigidbodyDOT
    {
        [Data]
        [SerializeField] Rigidbody _rigidbody;
        public override Rigidbody Rigidbody { get => _rigidbody; set => _rigidbody = value; }

        [Settings]
        [SerializeField] Vector3 endValue;
        public Vector3 EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] RotateMode mode;
        public RotateMode Mode { get => mode; set => mode = value; }

        [Events]
        [SerializeField] UnityEvent _event;
        public override UnityEvent Event { get => _event; set => _event = value; }

        public void DORotate(Vector3 newEndValue, float newDuration, RotateMode newMode)
        {
            endValue = newEndValue;
            duration = newDuration;
            mode = newMode;
            DORotate();
        }

        public void DORotate()
        {
            _rigidbody.DORotate(endValue, duration, mode);
            _event.Invoke();
        }
    }
}