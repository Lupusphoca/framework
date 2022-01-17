namespace PierreARNAUDET.Modules.DOT.CanvasGroups
{
    using UnityEngine;
    using UnityEngine.Events;

    public abstract class UCanvasGroupDOT : MonoBehaviour
    {
        public abstract CanvasGroup CanvasGroup { get; set; }

        public abstract UnityEvent Event { get; set; }
    }
}