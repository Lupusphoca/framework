namespace PierreARNAUDET.Modules.DOT.RectTransforms
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class PunchAnchorPosRectTransformDOT : URectTransformDOT
    {
        [Data]
        [SerializeField] RectTransform rectTransform;
        public override RectTransform RectTransform { get => rectTransform; set => rectTransform = value; }

        [Settings]
        [SerializeField] Vector2 punch;
        public Vector2 Punch { get => punch; set => punch = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] int vibrato;
        public int Vibrato { get => vibrato; set => vibrato = value; }
        [SerializeField] float elasticity;
        public float Elasticity { get => elasticity; set => elasticity = value; }
        [SerializeField] bool snapping;
        public bool Snapping { get => snapping; set => snapping = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOPunchAnchorPos(Vector2 newPunch, float newDuration, int newVibrato, float newElasticity, bool newSnapping)
        {
            punch = newPunch;
            duration = newDuration;
            vibrato = newVibrato;
            elasticity = newElasticity;
            snapping = newSnapping;
            DOPunchAnchorPos();
        }

        public void DOPunchAnchorPos()
        {
            rectTransform.DOPunchAnchorPos(punch, duration, vibrato, elasticity, snapping);
            @event.Invoke();
        }
    }
}