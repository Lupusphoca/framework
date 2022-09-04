namespace PierreARNAUDET.Modules.DOT.Transforms
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class ShakeRotationTransformDOT : UTransformDOT
    {
        [Data]
        [SerializeField] Transform _transform;
        public override Transform Transform { get => _transform; set => _transform = value; }

        [Settings]
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] float strength;
        public float Strength { get => strength; set => strength = value; }
        [SerializeField] int vibrato;
        public int Vibrato { get => vibrato; set => vibrato = value; }
        [SerializeField] float randomness;
        public float Randomness { get => randomness; set => randomness = value; }
        [SerializeField] bool fadeOut;
        public bool FadeOut { get => fadeOut; set => fadeOut = value; }

        [Events]
        [SerializeField] UnityEvent _event;
        public override UnityEvent Event { get => _event; set => _event = value; }

        public void DOShakeRotation(float newDuration, float newStrength, int newVibrato, float newRandomness, bool newFadeOut)
        {
            duration = newDuration;
            strength = newStrength;
            vibrato = newVibrato;
            randomness = newRandomness;
            fadeOut = newFadeOut;
            DOShakeRotation();
        }

        public void DOShakeRotation()
        {
            _transform.DOShakeRotation(duration, strength, vibrato, randomness, fadeOut);
            _event.Invoke();
        }
    }
}