namespace PierreARNAUDET.Core.Converters
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;
    using PierreARNAUDET.Core.Events;

    public class FloatToIntConverter : UConverter<float, int>
    {
        [Events]
        [SerializeField] IntEvent intConverted;

        protected override UnityEvent<int> ObjectConverted => intConverted;

        protected override int ConvertObject(float obj)
        {
            return (int)obj;
        }
    }
}