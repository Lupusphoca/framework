namespace Core.Raycasts
{
    using Events;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class OnGameObjectPointDown : MonoBehaviour, IPointerDownHandler
    {
        [Header("Events")]
        [SerializeField] PointerEventDataEvent pointerEventDataEvent;
        //[SerializeField] GameObjectEvent gameObjectEvent;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (pointerEventDataEvent != null) { pointerEventDataEvent.Invoke(eventData); }
            //if (gameObjectEvent != null) { gameObjectEvent.Invoke(this.gameObject); }
        }
    }
}
//WARNING : This component require a EventSystem in scene to work well