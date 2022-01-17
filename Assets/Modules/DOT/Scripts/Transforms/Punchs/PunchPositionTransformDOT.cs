namespace PierreARNAUDET.Modules.DOT.Transforms
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class PunchPositionTransformDOT : UTransformDOT
    {
        [Data]
        [SerializeField] Transform _transform;
        public override Transform Transform { get => _transform; set => _transform = value; }

        [Settings]
        [SerializeField] Vector3 punch;
        public Vector3 Punch { get => punch; set => punch = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] int vibrato;
        public int Vibrato { get => vibrato; set => vibrato = value; }
        [SerializeField] float elasticity;
        public float Elasticity { get => elasticity; set => elasticity = value; }
        [SerializeField] bool snapping;
        public bool Snapping { get => snapping; set => snapping = value; }

        [Events]
        [SerializeField] UnityEvent _event;
        public override UnityEvent Event { get => _event; set => _event = value; }

        public void DOPunchPosition(Vector3 newPunch, float newDuration, int newVibrato, float newElasticity, bool newSnapping)
        {
            punch = newPunch;
            duration = newDuration;
            vibrato = newVibrato;
            elasticity = newElasticity;
            snapping = newSnapping;
            DOPunchPosition();
        }

        public void DOPunchPosition()
        {
            _transform.DOPunchPosition(punch, duration, vibrato, elasticity, snapping);
            _event.Invoke();
        }
    }
}