namespace PierreARNAUDET.Modules.DOT.Images
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class FillAmountImageDOT : UImageDOT
    {
        [Data]
        [SerializeField] Image image;
        public override Image Image { get => image; set => image = value; }

        [Settings]
        [SerializeField] float endValue;
        public float EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOFillAmount(float newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DOFillAmount();
        }

        public void DOFillAmount()
        {
            image.DOFillAmount(endValue, duration);
            @event.Invoke();
        }
    }
}