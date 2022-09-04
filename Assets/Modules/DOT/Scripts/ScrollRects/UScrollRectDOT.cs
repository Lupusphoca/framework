namespace PierreARNAUDET.Modules.DOT.ScrollRects
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public abstract class UScrollRectDOT : MonoBehaviour
    {
        public abstract ScrollRect ScrollRect { get; set; }

        public abstract UnityEvent Event { get; set; }
    }
}