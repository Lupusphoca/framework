namespace PierreARNAUDET.Core.Events
{
    using System;

    using UnityEngine.Events;

    #region singular
    [Serializable] public class IntStringEvent : UnityEvent<int, string> { }
    [Serializable] public class StringStringEvent : UnityEvent<string, string> { }
    #endregion

    #region multiple
    #endregion

    #region singular scriptable
    #endregion

    #region multiple scriptable
    #endregion
}