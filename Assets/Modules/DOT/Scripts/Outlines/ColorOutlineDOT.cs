namespace PierreARNAUDET.Modules.DOT.Outlines
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class ColorOutlineDOT : UOutlineDOT
    {
        [Data]
        [SerializeField] Outline outline;
        public override Outline Outline { get => outline; set => outline = value; }

        [Settings]
        [SerializeField] Color endValue;
        public Color EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }

        [Events]
        [SerializeField] UnityEvent _event;
        public override UnityEvent Event { get => _event; set => _event = value; }

        public void DOColor(Color newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DOColor();
        }

        public void DOColor()
        {
            outline.DOColor(endValue, duration);
            _event.Invoke();
        }
    }
}