namespace PierreARNAUDET.Modules.DOT.Transforms
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class RotateQuaternionTransformDOT : UTransformDOT
    {
        [Data]
        [SerializeField] Transform _transform;
        public override Transform Transform { get => _transform; set => _transform = value; }

        [Settings]
        [SerializeField] Quaternion endValue;
        public Quaternion EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }

        [Events]
        [SerializeField] UnityEvent _event;
        public override UnityEvent Event { get => _event; set => _event = value; }

        public void DORotateQuaternion(Quaternion newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DORotateQuaternion();
        }

        public void DORotateQuaternion()
        {
            _transform.DORotateQuaternion(endValue, duration);
            _event.Invoke();
        }
    }
}