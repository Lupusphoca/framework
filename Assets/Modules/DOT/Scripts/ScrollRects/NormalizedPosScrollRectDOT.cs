namespace PierreARNAUDET.Modules.DOT.ScrollRects
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class NormalizedPosScrollRectDOT : UScrollRectDOT
    {
        [Data]
        [SerializeField] ScrollRect scrollRect;
        public override ScrollRect ScrollRect { get => scrollRect; set => scrollRect = value; }

        [Settings]
        [SerializeField] Vector2 endValue;
        public Vector2 EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] bool snapping;
        public bool Snapping { get => snapping; set => snapping = value; }

        [Events]
        [SerializeField] UnityEvent _event;
        public override UnityEvent Event { get => _event; set => _event = value; }

        public void DONormalizedPos(Vector2 newEndValue, float newDuration, bool newSnapping)
        {
            endValue = newEndValue;
            duration = newDuration;
            snapping = newSnapping;
            DONormalizedPos();
        }

        public void DONormalizedPos()
        {
            scrollRect.DONormalizedPos(endValue, duration, snapping);
            _event.Invoke();
        }
    }
}