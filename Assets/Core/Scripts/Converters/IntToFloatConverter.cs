namespace PierreARNAUDET.Core.Converters
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Events;

    public class IntToFloatConverter : UConverter<int, float>
    {
        [SerializeField] FloatEvent objectConverted;

        protected override UnityEvent<float> ObjectConverted => objectConverted;

        protected override float ConvertObject(int obj)
        {
            return (float)obj;
        }
    }
}