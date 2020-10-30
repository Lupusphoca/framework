namespace PierreARNAUDET.Modules.DOT.Lights
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class ColorLightDOT : ULightDOT
    {
        [Data]
        [SerializeField] Light light;
        public override Light Light { get => light; set => light = value; }

        [Settings]
        [SerializeField] Color color;
        public Color Color { get => color; set => color = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOColor(Color newColor, float newDuration)
        {
            color = newColor;
            duration = newDuration;
            DOColor();
        }

        public void DOColor()
        {
            light.DOColor(color, duration);
            @event.Invoke();
        }
    }
}