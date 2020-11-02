namespace PierreARNAUDET.Modules.DOT.Transforms
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class BlendableLocalRotateByTransformDOT : UTransformDOT
    {
        [Data]
        [SerializeField] Transform transform;
        public override Transform Transform { get => transform; set => transform = value; }

        [Settings]
        [SerializeField] Vector3 byValue;
        public Vector3 ByValue { get => byValue; set => byValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] RotateMode rotateMode;
        public RotateMode RotateMode { get => rotateMode; set => rotateMode = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOBlendableLocalRotateBy(Vector3 newByValue, float newDuration, RotateMode newRotateMode)
        {
            byValue = newByValue;
            duration = newDuration;
            rotateMode = newRotateMode;
            DOBlendableLocalRotateBy();
        }

        public void DOBlendableLocalRotateBy()
        {
            transform.DOBlendableLocalRotateBy(byValue, duration, rotateMode);
            @event.Invoke();
        }
    }
}