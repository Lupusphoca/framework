namespace PierreARNAUDET.Core.Pickers
{
    using PierreARNAUDET.Core.Extensions;

    using System;
    using System.Collections.Generic;

    public abstract class URandomPicker<T> : UPicker<T>
    {
        protected virtual Func<T, bool> WhereClause => null;

        protected override T PickObject(IEnumerable<T> objects) => objects.GetRandom(WhereClause);
    }
}