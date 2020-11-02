namespace PierreARNAUDET.Modules.DOT.SpriteRenderers
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class FadeSpriteRendererDOT : USpriteRendererDOT
    {
        [Data]
        [SerializeField] SpriteRenderer spriteRenderer;
        public override SpriteRenderer SpriteRenderer { get => spriteRenderer; set => spriteRenderer = value; }

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
            spriteRenderer.DOFade(endValue, duration);
            @event.Invoke();
        }
    }
}