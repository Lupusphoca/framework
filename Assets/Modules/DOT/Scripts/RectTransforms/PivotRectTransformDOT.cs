namespace PierreARNAUDET.Modules.DOT.RectTransforms
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class PivotRectTransformDOT : URectTransformDOT
    {
        [Data]
        [SerializeField] RectTransform rectTransform;
        public override RectTransform RectTransform { get => rectTransform; set => rectTransform = value; }

        [Settings]
        [SerializeField] Vector2 endValue;
        public Vector2 EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOPivot(Vector2 newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DOPivot();
        }

        public void DOPivot()
        {
            rectTransform.DOPivot(endValue, duration);
            @event.Invoke();
        }
    }
}