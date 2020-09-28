namespace PierreARNAUDET.Core.Converters
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Events;

    public class TransformToPositionConverter : UConverter<Transform, Vector3>
    {
        [Header("Events")]
        [SerializeField] Vector3Event positionConverted;

        protected override UnityEvent<Vector3> ObjectConverted => positionConverted;

        protected override Vector3 ConvertObject(Transform obj)
        {
            return obj.position;
        }
    }
}