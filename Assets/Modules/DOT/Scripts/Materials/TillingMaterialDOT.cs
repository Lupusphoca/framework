namespace PierreARNAUDET.Modules.DOT.Materials
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class TillingMaterialDOT : UMaterialDOT
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
        public void DOTiling_1(Vector2 newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DOTiling_1();
        }

        public void DOTiling_1()
        {
            material.DOTiling(endValue, duration);
            _event.Invoke();
        }
        #endregion

        #region V2
        public void DOTiling_2(Vector2 newEndValue, string newProperty, float newDuration)
        {
            endValue = newEndValue;
            property = newProperty;
            duration = newDuration;
            DOTiling_2();
        }

        public void DOTiling_2()
        {
            material.DOTiling(endValue, property, duration);
            _event.Invoke();
        }
        #endregion

        #region V3
        public void DOTiling_3(Vector2 newEndValue, int newPropertyID, float newDuration)
        {
            endValue = newEndValue;
            propertyID = newPropertyID;
            duration = newDuration;
            DOTiling_3();
        }

        public void DOTiling_3()
        {
            material.DOTiling(endValue, propertyID, duration);
            _event.Invoke();
        }
        #endregion
    }
}