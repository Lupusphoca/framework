namespace PierreARNAUDET.Modules.DOT.Lights
{
    using UnityEngine;
    using UnityEngine.Events;

    public abstract class ULightDOT : MonoBehaviour
    {
        public abstract Light Light { get; set; }

        public abstract UnityEvent @Event { get; set; }
    }
}