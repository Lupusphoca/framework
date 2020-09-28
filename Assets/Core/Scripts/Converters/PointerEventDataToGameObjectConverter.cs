namespace PierreARNAUDET.Core.Converters
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.EventSystems;

    using PierreARNAUDET.Core.Events;

    public class PointerEventDataToGameObjectConverter : UConverter<PointerEventData, GameObject>
    {
        [Header("Events")]
        [SerializeField] GameObjectEvent gameObjectConverted;

        protected override UnityEvent<GameObject> ObjectConverted => gameObjectConverted;

        protected override GameObject ConvertObject(PointerEventData obj)
        {
            return obj.selectedObject;
        }
    }
}
