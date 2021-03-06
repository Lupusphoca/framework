﻿namespace PierreARNAUDET.Core.Pointers
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    using PierreARNAUDET.Core.Events;

    public class OnGameObjectPointClick : MonoBehaviour, IPointerClickHandler
    {
        [Header("Events")]
        [SerializeField] PointerEventDataEvent pointerEventDataEvent;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (pointerEventDataEvent != null) { pointerEventDataEvent.Invoke(eventData); }
        }
    }
}
//WARNING : This component require a EventSystem and Physics Raycaster in scene to work well