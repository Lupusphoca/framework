namespace PierreARNAUDET.Modules.DOT.RectTransforms
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public abstract class URectTransformDOT : MonoBehaviour
    {
        public abstract RectTransform RectTransform { get; set; }

        public abstract UnityEvent @Event { get; set; }
    }
}