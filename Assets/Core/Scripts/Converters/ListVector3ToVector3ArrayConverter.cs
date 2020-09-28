namespace PierreARNAUDET.Core.Converters
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Events;

    public class ListVector3ToVector3ArrayConverter : UConverter<List<Vector3>, Vector3[]>
    {
        [Header("Events")]
        [SerializeField] Vector3ArrayEvent objectConverted;

        protected override UnityEvent<Vector3[]> ObjectConverted => objectConverted;

        protected override Vector3[] ConvertObject(List<Vector3> obj)
        {
            return obj.ToArray();
        }
    }
}