namespace PierreARNAUDET.Modules.DOT.Graphics
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class ColorGraphicDOT : UGraphicDOT
    {
        [Data]
        [SerializeField] Graphic graphic;
        public override Graphic Graphic { get => graphic; set => graphic = value; }

        [Settings]
        [SerializeField] Color endValue;
        public Color EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOColor(Color newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DOColor();
        }

        public void DOColor()
        {
            graphic.DOColor(endValue, duration);
            @event.Invoke();
        }
    }
}