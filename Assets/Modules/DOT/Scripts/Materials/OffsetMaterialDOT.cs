namespace PierreARNAUDET.Modules.DOT.Materials
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class OffsetMaterialDOT : UMaterialDOT
    {
        [Data]
        [SerializeField] Material material;
        public override Material Material { get => material; set => material = value; }

        [Settings]
        [SerializeField] Vector2 endValue;
        public Vector2 EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] string property;
        public string Property { get => property; set => property = value; }
        [SerializeField] int propertyID;
        public int PropertyID { get => propertyID; set => propertyID = value; }

        [Events]
        [SerializeField] UnityEvent _event;
        public override UnityEvent Event { get => _event; set => _event = value; }

        #region V1
        public void DOOffset_1(Vector2 newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DOOffset_1();
        }

        public void DOOffset_1()
        {
            material.DOOffset(endValue, duration);
            _event.Invoke();
        }
        #endregion

        #region V2
        public void DOOffset_2(Vector2 newEndValue, string newProperty, float newDuration)
        {
            endValue = newEndValue;
            property = newProperty;
            duration = newDuration;
            DOOffset_2();
        }

        public void DOOffset_2()
        {
            material.DOOffset(endValue, property, duration);
            _event.Invoke();
        }
        #endregion

        #region V3
        public void DOOffset_3(Vector2 newEndValue, int newPropertyID, float newDuration)
        {
            endValue = newEndValue;
            propertyID = newPropertyID;
            duration = newDuration;
            DOOffset_3();
        }

        public void DOOffset_3()
        {
            material.DOOffset(endValue, propertyID, duration);
            _event.Invoke();
        }
        #endregion
    }
}