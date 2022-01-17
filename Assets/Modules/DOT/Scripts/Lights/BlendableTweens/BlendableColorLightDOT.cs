namespace PierreARNAUDET.Modules.DOT.Lights
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class BlendableColorLightDOT : ULightDOT
    {
        [Data]
        [SerializeField] Light _light;
        public override Light Light { get => _light; set => _light = value; }

        [Settings]
        [SerializeField] Color color;
        public Color Color { get => color; set => color = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }

        [Events]
        [SerializeField] UnityEvent _event;
        public override UnityEvent Event { get => _event; set => _event = value; }

        public void DOBlendableColor(Color newColor, float newDuration)
        {
            color = newColor;
            duration = newDuration;
            DOBlendableColor();
        }

        public void DOBlendableColor()
        {
            _light.DOBlendableColor(color, duration);
            _event.Invoke();
        }
    }
}