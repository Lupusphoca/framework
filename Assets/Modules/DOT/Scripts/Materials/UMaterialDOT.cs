namespace PierreARNAUDET.Modules.DOT.Materials
{
    using UnityEngine;
    using UnityEngine.Events;

    public abstract class UMaterialDOT : MonoBehaviour
    {
        public abstract Material Material { get; set; }

        public abstract UnityEvent Event { get; set; }
    }
}