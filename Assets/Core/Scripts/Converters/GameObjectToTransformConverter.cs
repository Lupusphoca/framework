namespace PierreARNAUDET.Core.Converters
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Events;

    public class GameObjectToTransformConverter : UConverter<GameObject, Transform>
    {
        [SerializeField] TransformEvent objectConverted;

        protected override UnityEvent<Transform> ObjectConverted => objectConverted;

        protected override Transform ConvertObject(GameObject obj)
        {
           var transform = obj.GetComponent<Transform>();
           if (transform != null) {
               return transform;
           }
           return null;
        }
    }
}
