﻿namespace PierreARNAUDET.Modules.DOT.SpriteRenderers
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class BlendableColorSpriteRendererDOT : USpriteRendererDOT
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
            spriteRenderer.DOBlendableColor(endValue, duration);
            _event.Invoke();
        }
    }
}