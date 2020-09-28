namespace PierreARNAUDET.Core.Converters
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Events;

    public class Vector3ArrayToListVector3Converter : UConverter<Vector3[], List<Vector3>>
    {
        [Header("Events")]
        [SerializeField] Vector3ListEvent objectConverted;

        protected override UnityEvent<List<Vector3>> ObjectConverted => objectConverted;

        protected override List<Vector3> ConvertObject(Vector3[] obj)
        {
            var tmpList = new List<Vector3>();
            for (int i = 0; i < obj.Length; i++)
            {
                tmpList.Add(obj[i]);
            }
            return tmpList;
        }
    }
}