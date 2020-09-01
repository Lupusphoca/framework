namespace Core.Converters
{
    using Core.Events;
    using UnityEngine;
    using UnityEngine.Events;

    public class FloatToStringConverter : UConverter<float, string>
    {
        [Header("Out flow")]
        [SerializeField] StringEvent stringConverted;
        protected override UnityEvent<string> ObjectConverted => stringConverted;

        protected override string ConvertObject(float obj)
        {
            return obj.ToString();
        }
    }
}
