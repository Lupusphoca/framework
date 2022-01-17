namespace PierreARNAUDET.Modules.DOT.Transforms
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class LocalRotateQuaternionTransformDOT : UTransformDOT
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

        public void DOLocalRotateQuaternion(Quaternion newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DOLocalRotateQuaternion();
        }

        public void DOLocalRotateQuaternion()
        {
            _transform.DOLocalRotateQuaternion(endValue, duration);
            _event.Invoke();
        }
    }
}