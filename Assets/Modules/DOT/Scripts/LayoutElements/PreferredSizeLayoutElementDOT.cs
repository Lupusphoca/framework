namespace PierreARNAUDET.Modules.DOT.LayoutElements
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class PreferredSizeLayoutElement : ULayoutElementDOT
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
        [SerializeField] UnityEvent _event;
        public override UnityEvent Event { get => _event; set => _event = value; }

        public void DOPreferredSize(Vector2 newEndValue, float newDuration, bool newSnapping)
        {
            endValue = newEndValue;
            duration = newDuration;
            snapping = newSnapping;
            DOPreferredSize();
        }

        public void DOPreferredSize()
        {
            layoutElement.DOPreferredSize(endValue, duration, snapping);
            _event.Invoke();
        }
    }
}