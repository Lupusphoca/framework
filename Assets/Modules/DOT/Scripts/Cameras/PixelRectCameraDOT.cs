namespace PierreARNAUDET.Modules.DOT.Cameras
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class PixelRectCameraDOT : UCameraDOT
    {
        [Data]
        [SerializeField] Camera camera;
        public override Camera Camera { get => camera; set => camera = value; }

        [Settings]
        [SerializeField] Rect endValue;
        public Rect EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOPixelRect(Rect newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DOPixelRect();
        }

        public void DOPixelRect()
        {
            camera.DOPixelRect(endValue, duration);
            @event.Invoke();
        }
    }
}