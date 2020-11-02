namespace PierreARNAUDET.Modules.DOT.LayoutElements
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class FlexibleSizeLayoutElement : ULayoutElementDOT
    {
        [Data]
        [SerializeField] LayoutElement layoutElement;
        public override LayoutElement LayoutElement { get => layoutElement; set => layoutElement = value; }

        [Settings]
        [SerializeField] Vector2 endValue;
        public Vector2 EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] bool snapping;
        public bool Snapping { get => snapping; set => snapping = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOFlexibleSize(Vector2 newEndValue, float newDuration, bool newSnapping)
        {
            endValue = newEndValue;
            duration = newDuration;
            snapping = newSnapping;
            DOFlexibleSize();
        }

        public void DOFlexibleSize()
        {
            layoutElement.DOFlexibleSize(endValue, duration, snapping);
            @event.Invoke();
        }
    }
}