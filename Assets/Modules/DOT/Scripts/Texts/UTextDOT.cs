namespace PierreARNAUDET.Modules.DOT.Texts
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public abstract class UTextDOT : MonoBehaviour
    {
        public abstract Text Text { get; set; }

        public abstract UnityEvent @Event { get; set; }
    }
}