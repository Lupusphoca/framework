namespace PierreARNAUDET.Core.Converters
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Events;

    public class Vector2ToStringConverter : UConverter<Vector2, string>
    {
        [Header("Events")]
        [SerializeField] StringEvent stringConverted;
        protected override UnityEvent<string> ObjectConverted => stringConverted;

        protected override string ConvertObject(Vector2 obj)
        {
            return obj.ToString();
        }
    }
}