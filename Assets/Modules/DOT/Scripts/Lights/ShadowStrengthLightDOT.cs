namespace PierreARNAUDET.Modules.DOT.Lights
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class ShadowStrengthLightDOT : ULightDOT
    {
        [Data]
        [SerializeField] Light _light;
        public override Light Light { get => _light; set => _light = value; }

        [Settings]
        [SerializeField] float endValue;
        public float EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }

        [Events]
        [SerializeField] UnityEvent _event;
        public override UnityEvent Event { get => _event; set => _event = value; }

        public void DOShadowStrength(float newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DOShadowStrength();
        }

        public void DOShadowStrength()
        {
            _light.DOShadowStrength(endValue, duration);
            _event.Invoke();
        }
    }
}