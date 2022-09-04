namespace PierreARNAUDET.Modules.DOT.Transforms
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class PunchRotationTransformDOT : UTransformDOT
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

        [Events]
        [SerializeField] UnityEvent _event;
        public override UnityEvent Event { get => _event; set => _event = value; }

        public void DOPunchRotation(Vector3 newPunch, float newDuration, int newVibrato, float newElasticity)
        {
            punch = newPunch;
            duration = newDuration;
            vibrato = newVibrato;
            elasticity = newElasticity;
            DOPunchRotation();
        }

        public void DOPunchRotation()
        {
            _transform.DOPunchRotation(punch, duration, vibrato, elasticity);
            _event.Invoke();
        }
    }
}