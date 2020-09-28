namespace PierreARNAUDET.Core.Converters
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Events;

    public class Vector3XYToVector2Converter : UConverter<Vector3, Vector2>
    {
        [Header("Events")]
        [SerializeField] Vector2Event vector2Converted;
        protected override UnityEvent<Vector2> ObjectConverted => vector2Converted;

        protected override Vector2 ConvertObject(Vector3 obj)
        {
            return new Vector2(obj.x, obj.y);
        }
    }
}