namespace PierreARNAUDET.Modules.DOT.TrailRenderers
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class ResizeTrailRendererDOT : UTrailRendererDOT
    {
        [Data]
        [SerializeField] TrailRenderer trailRenderer;
        public override TrailRenderer TrailRenderer { get => trailRenderer; set => trailRenderer = value; }

        [Settings]
        [SerializeField] float startWidth;
        public float StartWidth { get => startWidth; set => startWidth = value; }
        [SerializeField] float endWidth;
        public float EndWidth { get => endWidth; set => endWidth = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOResize(float newStartWidth, float newEndWidth, float newDuration)
        {
            startWidth = newStartWidth;
            endWidth = newEndWidth;
            duration = newDuration;
            DOResize();
        }

        public void DOResize()
        {
            trailRenderer.DOResize(startWidth, endWidth, duration);
            @event.Invoke();
        }
    }
}