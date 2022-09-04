namespace PierreARNAUDET.Modules.DOT.Images
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class BlendableColorImageDOT : UImageDOT
    {
        [Data]
        [SerializeField] Image image;
        public override Image Image { get => image; set => image = value; }

        [Settings]
        [SerializeField] Color endValue;
        public Color EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }

        [Events]
        [SerializeField] UnityEvent _event;
        public override UnityEvent Event { get => _event; set => _event = value; }

        public void DOBlendableColor(Color newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DOBlendableColor();
        }

        public void DOBlendableColor()
        {
            image.DOBlendableColor(endValue, duration);
            _event.Invoke();
        }
    }
}