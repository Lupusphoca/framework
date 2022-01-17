namespace PierreARNAUDET.Modules.DOT.SpriteRenderers
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class GradientColorSpriteRendererDOT : USpriteRendererDOT
    {
        [Data]
        [SerializeField] SpriteRenderer spriteRenderer;
        public override SpriteRenderer SpriteRenderer { get => spriteRenderer; set => spriteRenderer = value; }

        [Settings]
        [SerializeField] Gradient endValue;
        public Gradient EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }

        [Events]
        [SerializeField] UnityEvent _event;
        public override UnityEvent Event { get => _event; set => _event = value; }

        public void DOFade(Gradient newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DOFade();
        }

        public void DOFade()
        {
            spriteRenderer.DOGradientColor(endValue, duration);
            _event.Invoke();
        }
    }
}