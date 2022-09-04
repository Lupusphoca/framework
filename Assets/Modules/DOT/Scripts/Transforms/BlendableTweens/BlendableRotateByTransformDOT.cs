namespace PierreARNAUDET.Modules.DOT.Transforms
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class BlendableRotateByTransformDOT : UTransformDOT
    {
        [Data]
        [SerializeField] Transform _transform;
        public override Transform Transform { get => _transform; set => _transform = value; }

        [Settings]
        [SerializeField] Vector3 byValue;
        public Vector3 ByValue { get => byValue; set => byValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] RotateMode rotateMode;
        public RotateMode RotateMode { get => rotateMode; set => rotateMode = value; }

        [Events]
        [SerializeField] UnityEvent _event;
        public override UnityEvent Event { get => _event; set => _event = value; }

        public void DOBlendableRotateBy(Vector3 newByValue, float newDuration, RotateMode newRotateMode)
        {
            byValue = newByValue;
            duration = newDuration;
            rotateMode = newRotateMode;
            DOBlendableRotateBy();
        }

        public void DOBlendableRotateBy()
        {
            _transform.DOBlendableRotateBy(byValue, duration, rotateMode);
            _event.Invoke();
        }
    }
}