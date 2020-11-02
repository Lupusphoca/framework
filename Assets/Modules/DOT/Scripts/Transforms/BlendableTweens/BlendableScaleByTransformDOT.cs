namespace PierreARNAUDET.Modules.DOT.Transforms
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class BlendableScaleByTransformDOT : UTransformDOT
    {
        [Data]
        [SerializeField] Transform transform;
        public override Transform Transform { get => transform; set => transform = value; }

        [Settings]
        [SerializeField] Vector3 byValue;
        public Vector3 ByValue { get => byValue; set => byValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOBlendableScaleBy(Vector3 newByValue, float newDuration)
        {
            byValue = newByValue;
            duration = newDuration;
            DOBlendableScaleBy();
        }

        public void DOBlendableScaleBy()
        {
            transform.DOBlendableScaleBy(byValue, duration);
            @event.Invoke();
        }
    }
}