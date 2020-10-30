namespace PierreARNAUDET.Modules.DOT.Materials
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class FloatMaterialDOT : UMaterialDOT
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
        public void DOFloat_1(float newEndValue, string newProperty, float newDuration)
        {
            endValue = newEndValue;
            property = newProperty;
            duration = newDuration;
            DOFloat_1();
        }

        public void DOFloat_1()
        {
            material.DOFloat(endValue, property, duration);
            @event.Invoke();
        }
        #endregion

        #region V2
        public void DOFloat_2(float newEndValue, int newPropertyID, float newDuration)
        {
            endValue = newEndValue;
            propertyID = newPropertyID;
            duration = newDuration;
            DOFloat_2();
        }

        public void DOFloat_2()
        {
            material.DOFloat(endValue, propertyID, duration);
            @event.Invoke();
        }
        #endregion
    }
}