namespace PierreARNAUDET.Modules.DOT.Materials
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class GradientColorMaterialDOT : UMaterialDOT
    {
        [Data]
        [SerializeField] Material material;
        public override Material Material { get => material; set => material = value; }

        [Settings]
        [SerializeField] Gradient endValue;
        public Gradient EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] string property;
        public string Property { get => property; set => property = value; }

        [Events]
        [SerializeField] UnityEvent _event;
        public override UnityEvent Event { get => _event; set => _event = value; }

        #region V1
        public void DOGradientColor_1(Gradient newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DOGradientColor_1();
        }

        public void DOGradientColor_1()
        {
            material.DOGradientColor(endValue, duration);
            _event.Invoke();
        }
        #endregion

        #region V2
        public void DOGradientColor_2(Gradient newEndValue, string newProperty, float newDuration)
        {
            endValue = newEndValue;
            property = newProperty;
            duration = newDuration;
            DOGradientColor_2();
        }

        public void DOGradientColor_2()
        {
            material.DOGradientColor(endValue, property, duration);
            _event.Invoke();
        }
        #endregion
    }
}