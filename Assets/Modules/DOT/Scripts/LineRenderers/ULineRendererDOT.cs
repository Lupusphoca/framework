namespace PierreARNAUDET.Modules.DOT.LineRenderers
{
    using UnityEngine;
    using UnityEngine.Events;

    public abstract class ULineRendererDOT : MonoBehaviour
    {
        public abstract LineRenderer LineRenderer { get; set; }

        public abstract UnityEvent @Event { get; set; }
    }
}