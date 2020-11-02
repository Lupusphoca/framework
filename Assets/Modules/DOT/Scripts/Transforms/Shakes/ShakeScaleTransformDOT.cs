namespace PierreARNAUDET.Modules.DOT.Transforms
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class ShakeScaleTransformDOT : UTransformDOT
    {
        [Data]
        [SerializeField] Transform transform;
        public override Transform Transform { get => transform; set => transform = value; }

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
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOShakeScale(float newDuration, float newStrength, int newVibrato, float newRandomness, bool newFadeOut)
        {
            duration = newDuration;
            strength = newStrength;
            vibrato = newVibrato;
            randomness = newRandomness;
            fadeOut = newFadeOut;
            DOShakeScale();
        }

        public void DOShakeScale()
        {
            transform.DOShakeScale(duration, strength, vibrato, randomness, fadeOut);
            @event.Invoke();
        }
    }
}