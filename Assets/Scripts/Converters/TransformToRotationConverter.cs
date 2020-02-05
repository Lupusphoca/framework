namespace Core.Converters
{
    using UnityEngine;
    using UnityEngine.Events;

    using Core.Events;

    public class TransformToRotationConverter : UConverter<Transform, Quaternion>
    {
        [Header("Events")]
        [SerializeField] QuaternionEvent rotationConverted;

        protected override UnityEvent<Quaternion> ObjectConverted => rotationConverted;

        protected override Quaternion ConvertObject(Transform obj)
        {
            return obj.rotation;
        }
    }
}
