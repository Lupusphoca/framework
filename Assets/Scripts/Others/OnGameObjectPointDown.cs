namespace Core.Raycasts
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using Events;

    public class OnGameObjectPointDown : MonoBehaviour, IPointerDownHandler
    {
        [Header("Events")]
        [SerializeField] GameObjectEvent gameObjectEvent;
        [SerializeField] PointerEventDataEvent pointerEventDataEvent;

        public void OnPointerDown(PointerEventData eventData)
        {
            pointerEventDataEvent.Invoke(eventData);
            gameObjectEvent.Invoke(this.gameObject);
        }
    }
}