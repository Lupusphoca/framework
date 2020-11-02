﻿namespace PierreARNAUDET.Modules.DOT.Transforms
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class ShakePositionTransformDOT : UTransformDOT
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
        [SerializeField] bool snapping;
        public bool Snapping { get => snapping; set => snapping = value; }
        [SerializeField] bool fadeOut;
        public bool FadeOut { get => fadeOut; set => fadeOut = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOShakePosition(float newDuration, float newStrength, int newVibrato, float newRandomness, bool newSnapping, bool newFadeOut)
        {
            duration = newDuration;
            strength = newStrength;
            vibrato = newVibrato;
            randomness = newRandomness;
            snapping = newSnapping;
            fadeOut = newFadeOut;
            DOShakePosition();
        }

        public void DOShakePosition()
        {
            transform.DOShakePosition(duration, strength, vibrato, randomness, snapping, fadeOut);
            @event.Invoke();
        }
    }
}