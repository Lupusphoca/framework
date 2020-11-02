namespace PierreARNAUDET.Modules.DOT.Texts
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class BlendableColorTextDOT : UTextDOT
    {
        [Data]
        [SerializeField] Text text;
        public override Text Text { get => text; set => text = value; }

        [Settings]
        [SerializeField] Color endValue;
        public Color EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] bool snapping;
        public bool Snapping { get => snapping; set => snapping = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOBlendableColor(Color newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DOBlendableColor();
        }

        public void DOBlendableColor()
        {
            text.DOBlendableColor(endValue, duration);
            @event.Invoke();
        }
    }
}