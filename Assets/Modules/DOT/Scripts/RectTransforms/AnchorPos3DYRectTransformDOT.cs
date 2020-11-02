namespace PierreARNAUDET.Modules.DOT.RectTransforms
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class AnchorPos3DYRectTransformDOT : URectTransformDOT
    {
        [Data]
        [SerializeField] RectTransform rectTransform;
        public override RectTransform RectTransform { get => rectTransform; set => rectTransform = value; }

        [Settings]
        [SerializeField] float endValue;
        public float EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] bool snapping;
        public bool Snapping { get => snapping; set => snapping = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOAnchorPos3DY(float newEndValue, float newDuration, bool newSnapping)
        {
            endValue = newEndValue;
            duration = newDuration;
            snapping = newSnapping;
            DOAnchorPos3DY();
        }

        public void DOAnchorPos3DY()
        {
            rectTransform.DOAnchorPos3DY(endValue, duration, snapping);
            @event.Invoke();
        }
    }
}