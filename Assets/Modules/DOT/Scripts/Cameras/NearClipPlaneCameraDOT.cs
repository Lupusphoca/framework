namespace PierreARNAUDET.Modules.DOT.Cameras
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class NearClipPlaneCameraDOT : UCameraDOT
    {
        [Data]
        [SerializeField] Camera camera;
        public override Camera Camera { get => camera; set => camera = value; }

        [Settings]
        [SerializeField] float endValue;
        public float EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DONearClipPlane(float newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DONearClipPlane();
        }

        public void DONearClipPlane()
        {
            camera.DONearClipPlane(endValue, duration);
            @event.Invoke();
        }
    }
}