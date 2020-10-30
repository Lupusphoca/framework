namespace PierreARNAUDET.Modules.DOT.Cameras
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class ShakePositionCameraDOT : UCameraDOT
    {
        [Data]
        [SerializeField] Camera camera;
        public override Camera Camera { get => camera; set => camera = value; }

        [Settings]
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] float strength;
        public float Strength { get => strength; set => strength = value; }
        [SerializeField] int vibrato;
        public int Vibrato { get => vibrato; set => vibrato = value; }
        [SerializeField] float randomness;
        public float Randomness { get => randomness; set => randomness = value; }
        [SerializeField] bool fadeout;
        public bool Fadeout { get => fadeout; set => fadeout = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOShakePosition(float newDuration, float newStrength, int newVibrato, float newRandomness, bool newFadeOut)
        {
            duration = newDuration;
            strength = newStrength;
            vibrato = newVibrato;
            randomness = newRandomness;
            fadeout = newFadeOut;
            DOShakePosition();
        }

        public void DOShakePosition()
        {
            camera.DOShakePosition(duration, strength, vibrato, randomness, fadeout);
            @event.Invoke();
        }
    }
}