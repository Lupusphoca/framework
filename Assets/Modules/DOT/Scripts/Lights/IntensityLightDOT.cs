namespace PierreARNAUDET.Modules.DOT.Lights
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class IntensityLightDOT : ULightDOT
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

        public void DOIntensity(float newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DOIntensity();
        }

        public void DOIntensity()
        {
            _light.DOIntensity(endValue, duration);
            _event.Invoke();
        }
    }
}