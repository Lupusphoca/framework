namespace Core.Pointers
{
    using Events;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class OnGameObjectPointDown : MonoBehaviour, IPointerDownHandler
    {
        [Header("Events")]
        [SerializeField] PointerEventDataEvent pointerEventDataEvent;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (pointerEventDataEvent != null) { pointerEventDataEvent.Invoke(eventData); }
        }
    }
}
//WARNING : This component require a EventSystem and Physics Raycaster in SCENE to work well