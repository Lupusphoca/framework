namespace PierreARNAUDET.Modules.DOT.Materials
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class VectorMaterialDOT : UMaterialDOT
    {
        [Data]
        [SerializeField] Material material;
        public override Material Material { get => material; set => material = value; }

        [Settings]
        [SerializeField] Vector4 endValue;
        public Vector4 EndValue { get => endValue; set => endValue = value; }
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
        public void DOVector_1(Vector4 newEndValue, string newProperty, float newDuration)
        {
            endValue = newEndValue;
            property = newProperty;
            duration = newDuration;
            DOVector_1();
        }

        public void DOVector_1()
        {
            material.DOVector(endValue, property, duration);
            @event.Invoke();
        }
        #endregion

        #region V2
        public void DOVector_2(Vector4 newEndValue, int newpPropertyID, float newDuration)
        {
            endValue = newEndValue;
            propertyID = newpPropertyID;
            duration = newDuration;
            DOVector_2();
        }

        public void DOVector_2()
        {
            material.DOVector(endValue, propertyID, duration);
            @event.Invoke();
        }
        #endregion
    }
}