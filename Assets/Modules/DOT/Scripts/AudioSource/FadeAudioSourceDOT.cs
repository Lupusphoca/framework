namespace PierreARNAUDET.Modules.DOT
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class FadeAudioSourceDOT : UAudioSourceDOT
    {
        [Data]
        [SerializeField] AudioSource audioSource;
        public override AudioSource AudioSource { get => audioSource; set => audioSource = value; }
        [SerializeField] float endValue;
        public float EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOFade(float newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DOFade();
        }

        public void DOFade()
        {
            audioSource.DOFade(endValue, duration);
            @event.Invoke();
        }
    }
}