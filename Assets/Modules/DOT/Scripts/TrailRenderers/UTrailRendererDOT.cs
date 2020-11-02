namespace PierreARNAUDET.Modules.DOT.TrailRenderers
{
    using UnityEngine;
    using UnityEngine.Events;

    public abstract class UTrailRendererDOT : MonoBehaviour
    {
        public abstract TrailRenderer TrailRenderer { get; set; }

        public abstract UnityEvent @Event { get; set; }
    }
}