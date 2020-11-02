namespace PierreARNAUDET.Modules.DOT.Outlines
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class FadeOutlineDOT : UOutlineDOT
    {
        [Data]
        [SerializeField] Outline outline;
        public override Outline Outline { get => outline; set => outline = value; }

        [Settings]
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
            outline.DOFade(endValue, duration);
            @event.Invoke();
        }
    }
}