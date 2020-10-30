namespace PierreARNAUDET.Modules.DOT.Lights
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class ShadowStrengthLightDOT : ULightDOT
    {
        [Data]
        [SerializeField] Light light;
        public override Light Light { get => light; set => light = value; }

        [Settings]
        [SerializeField] float endValue;
        public float EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOShadowStrength(float newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DOShadowStrength();
        }

        public void DOShadowStrength()
        {
            light.DOShadowStrength(endValue, duration);
            @event.Invoke();
        }
    }
}