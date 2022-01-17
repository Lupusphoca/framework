namespace PierreARNAUDET.Modules.DOT.Outlines
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public abstract class UOutlineDOT : MonoBehaviour
    {
        public abstract Outline Outline { get; set; }

        public abstract UnityEvent Event { get; set; }
    }
}