namespace PierreARNAUDET.Modules.DOT.LayoutElements
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public abstract class ULayoutElementDOT : MonoBehaviour
    {
        public abstract LayoutElement LayoutElement { get; set; }

        public abstract UnityEvent @Event { get; set; }
    }
}