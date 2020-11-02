namespace PierreARNAUDET.Modules.DOT.Sliders
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class ValueSliderDOT : USliderDOT
    {
        [Data]
        [SerializeField] Slider slider;
        public override Slider Slider { get => slider; set => slider = value; }

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

        public void DOValue(float newEndValue, float newDuration, bool newSnapping)
        {
            endValue = newEndValue;
            duration = newDuration;
            snapping = newSnapping;
            DOValue();
        }

        public void DOValue()
        {
            slider.DOValue(endValue, duration, snapping);
            @event.Invoke();
        }
    }
}