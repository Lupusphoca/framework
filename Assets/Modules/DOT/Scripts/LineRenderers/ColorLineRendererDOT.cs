namespace PierreARNAUDET.Modules.DOT.LineRenderers
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class ColorLineRendererDOT : ULineRendererDOT
    {
        [Data]
        [SerializeField] LineRenderer lineRenderer;
        public override LineRenderer LineRenderer { get => lineRenderer; set => lineRenderer = value; }

        [Settings]
        [SerializeField] Color2 startValue;
        public Color2 StartValue { get => startValue; set => startValue = value; }
        [SerializeField] Color2 endValue;
        public Color2 EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }

        [Events]
        [SerializeField] UnityEvent _event;
        public override UnityEvent Event { get => _event; set => _event = value; }

        public void DOColor(Color2 newStartValue, Color2 newEndValue, float newDuration)
        {
            startValue = newStartValue;
            endValue = newEndValue;
            duration = newDuration;
            DOColor();
        }

        public void DOColor()
        {
            lineRenderer.DOColor(startValue, endValue, duration);
            _event.Invoke();
        }
    }
}