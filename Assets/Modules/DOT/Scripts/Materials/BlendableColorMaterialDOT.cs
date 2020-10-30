namespace PierreARNAUDET.Modules.DOT.Materials
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class BlendableColorMaterialDOT : UMaterialDOT
    {
        [Data]
        [SerializeField] Material material;
        public override Material Material { get => material; set => material = value; }

        [Settings]
        [SerializeField] Color endValue;
        public Color EndValue { get => endValue; set => endValue = value; }
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
        public void DOBlendableColor_1(Color newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DOBlendableColor_1();
        }

        public void DOBlendableColor_1()
        {
            material.DOBlendableColor(endValue, duration);
            @event.Invoke();
        }
        #endregion

        #region V2
        public void DOBlendableColor_2(Color newEndValue, string newProperty, float newDuration)
        {
            endValue = newEndValue;
            property = newProperty;
            duration = newDuration;
            DOBlendableColor_2();
        }

        public void DOBlendableColor_2()
        {
            material.DOBlendableColor(endValue, property, duration);
            @event.Invoke();
        }
        #endregion

        #region V3
        public void DOBlendableColor_3(Color newEndValue, int newPropertyID, float newDuration)
        {
            endValue = newEndValue;
            propertyID = newPropertyID;
            duration = newDuration;
            DOBlendableColor_3();
        }

        public void DOBlendableColor_3()
        {
            material.DOBlendableColor(endValue, propertyID, duration);
            @event.Invoke();
        }
        #endregion
    }
}