namespace PierreARNAUDET.Modules.DOT.SpriteRenderers
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class ColorSpriteRendererDOT : USpriteRendererDOT
    {
        [Data]
        [SerializeField] SpriteRenderer spriteRenderer;
        public override SpriteRenderer SpriteRenderer { get => spriteRenderer; set => spriteRenderer = value; }

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
            spriteRenderer.DOColor(endValue, duration);
            @event.Invoke();
        }
    }
}