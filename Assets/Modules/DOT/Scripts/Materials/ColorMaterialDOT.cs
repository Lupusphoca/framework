﻿namespace PierreARNAUDET.Modules.DOT.Materials
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class ColorMaterialDOT : UMaterialDOT
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
        [SerializeField] UnityEvent _event;
        public override UnityEvent Event { get => _event; set => _event = value; }

        #region V1
        public void DOColor_1(Color newEndValue, float newDuration)
        {
            endValue = newEndValue;
            duration = newDuration;
            DOColor_1();
        }

        public void DOColor_1()
        {
            material.DOColor(endValue, duration);
            _event.Invoke();
        }
        #endregion

        #region V2
        public void DOColor_2(Color newEndValue, string newProperty, float newDuration)
        {
            endValue = newEndValue;
            property = newProperty;
            duration = newDuration;
            DOColor_2();
        }

        public void DOColor_2()
        {
            material.DOColor(endValue, property, duration);
            _event.Invoke();
        }
        #endregion

        #region V3
        public void DOColor_3(Color newEndValue, int newPropertyID, float newDuration)
        {
            endValue = newEndValue;
            propertyID = newPropertyID;
            duration = newDuration;
            DOColor_3();
        }

        public void DOColor_3()
        {
            material.DOColor(endValue, propertyID, duration);
            _event.Invoke();
        }
        #endregion
    }
}