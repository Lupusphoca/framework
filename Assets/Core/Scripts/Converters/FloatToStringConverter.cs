namespace PierreARNAUDET.Core.Converters
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Events;

    public class FloatToStringConverter : UConverter<float, string>
    {
        [Header("Events")]
        [SerializeField] StringEvent stringConverted;
        protected override UnityEvent<string> ObjectConverted => stringConverted;

        protected override string ConvertObject(float obj)
        {
            return obj.ToString();
        }
    }
}