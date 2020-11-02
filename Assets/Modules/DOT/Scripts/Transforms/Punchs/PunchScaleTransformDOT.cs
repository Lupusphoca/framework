namespace PierreARNAUDET.Modules.DOT.Transforms
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class PunchScaleTransformDOT : UTransformDOT
    {
        [Data]
        [SerializeField] Transform transform;
        public override Transform Transform { get => transform; set => transform = value; }

        [Settings]
        [SerializeField] Vector3 punch;
        public Vector3 Punch { get => punch; set => punch = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] int vibrato;
        public int Vibrato { get => vibrato; set => vibrato = value; }
        [SerializeField] float elasticity;
        public float Elasticity { get => elasticity; set => elasticity = value; }


        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOPunchScale(Vector3 newPunch, float newDuration, int newVibrato, float newElasticity)
        {
            punch = newPunch;
            duration = newDuration;
            vibrato = newVibrato;
            elasticity = newElasticity;
            DOPunchScale();
        }

        public void DOPunchScale()
        {
            transform.DOPunchScale(punch, duration, vibrato, elasticity);
            @event.Invoke();
        }
    }
}