namespace PierreARNAUDET.Modules.DOT.CanvasGroups
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class FadeCanvasGroupDOT : UCanvasGroupDOT
    {
        [Data]
        [SerializeField] CanvasGroup canvasGroup;
        public override CanvasGroup CanvasGroup { get => canvasGroup; set => canvasGroup = value; }

        [Settings]
        [SerializeField] float endValue;
        public float EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }

        [Events]
        [SerializeField] UnityEvent _event;
        public override UnityEvent Event { get => _event; set => _event = value; }

        public void DOFade(float newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DOFade();
        }

        public void DOFade()
        {
            canvasGroup.DOFade(endValue, duration);
            _event.Invoke();
        }
    }
}