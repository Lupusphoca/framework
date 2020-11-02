namespace PierreARNAUDET.Modules.DOT.Images
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public abstract class UImageDOT : MonoBehaviour
    {
        public abstract Image Image { get; set; }

        public abstract UnityEvent @Event { get; set; }
    }
}