namespace PierreARNAUDET.Modules.DOT.TrailRenderers
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class TimeTrailRendererDOT : UTrailRendererDOT
    {
        [Data]
        [SerializeField] TrailRenderer trailRenderer;
        public override TrailRenderer TrailRenderer { get => trailRenderer; set => trailRenderer = value; }

        [Settings]
        [SerializeField] float endValue;
        public float EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOTime(float newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DOTime();
        }

        public void DOTime()
        {
            trailRenderer.DOTime(endValue, duration);
            @event.Invoke();
        }
    }
}