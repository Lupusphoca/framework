namespace PierreARNAUDET.Modules.DOT.SpriteRenderers
{
    using UnityEngine;
    using UnityEngine.Events;

    public abstract class USpriteRendererDOT : MonoBehaviour
    {
        public abstract SpriteRenderer SpriteRenderer { get; set; }

        public abstract UnityEvent Event { get; set; }
    }
}