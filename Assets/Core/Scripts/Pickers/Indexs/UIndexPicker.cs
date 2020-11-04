namespace PierreARNAUDET.Core.Pickers
{
    using PierreARNAUDET.Core.Attributes;

    using System.Linq;
    using System.Collections.Generic;

    using UnityEngine;

    public abstract class UIndexPicker<T> : UPicker<T>
    {
        [Data, SerializeField] int indexToPick;

        public int IndexToPick { get => indexToPick; set => indexToPick = value; }

        protected override T PickObject(IEnumerable<T> objects) => objects.ElementAt(IndexToPick);
    }
}