namespace PierreARNAUDET.Modules.DOT.ScrollRects
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class HorizontalNormalizedPosScrollRectDOT : UScrollRectDOT
    {
        [Data]
        [SerializeField] ScrollRect scrollRect;
        public override ScrollRect ScrollRect { get => scrollRect; set => scrollRect = value; }

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

        public void DOHorizontalNormalizedPos(float newEndValue, float newDuration, bool newSnapping)
        {
            endValue = newEndValue;
            duration = newDuration;
            snapping = newSnapping;
            DOHorizontalNormalizedPos();
        }

        public void DOHorizontalNormalizedPos()
        {
            scrollRect.DOHorizontalNormalizedPos(endValue, duration, snapping);
            @event.Invoke();
        }
    }
}