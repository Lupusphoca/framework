namespace PierreARNAUDET.Modules.DOT.Materials
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class FadeMaterialDOT : UMaterialDOT
    {
        [Data]
        [SerializeField] Material material;
        public override Material Material { get => material; set => material = value; }

        [Settings]
        [SerializeField] float endValue;
        public float EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] string property;
        public string Property { get => property; set => property = value; }
        [SerializeField] int propertyID;
        public int PropertyID { get => propertyID; set => propertyID = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        #region V1
        public void DOFade_1(float newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DOFade_1();
        }

        public void DOFade_1()
        {
            material.DOFade(endValue, duration);
            @event.Invoke();
        }
        #endregion

        #region V2
        public void DOFade_2(float newEndValue, string newProperty, float newDuration)
        {
            endValue = newEndValue;
            property = newProperty;
            duration = newDuration;
            DOFade_2();
        }

        public void DOFade_2()
        {
            material.DOFade(endValue, property, duration);
            @event.Invoke();
        }
        #endregion

        #region V3
        public void DOFade_3(float newEndValue, int newPropertyID, float newDuration)
        {
            endValue = newEndValue;
            propertyID = newPropertyID;
            duration = newDuration;
            DOFade_3();
        }

        public void DOFade_3()
        {
            material.DOFade(endValue, propertyID, duration);
            @event.Invoke();
        }
        #endregion
    }
}