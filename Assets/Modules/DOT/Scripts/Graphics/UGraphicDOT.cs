namespace PierreARNAUDET.Modules.DOT.Graphics
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public abstract class UGraphicDOT : MonoBehaviour
    {
        public abstract Graphic Graphic { get; set; }

        public abstract UnityEvent Event { get; set; }
    }
}