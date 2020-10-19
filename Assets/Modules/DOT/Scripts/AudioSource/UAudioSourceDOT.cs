namespace PierreARNAUDET.Modules.DOT
{
    using UnityEngine;
    using UnityEngine.Events;

    public abstract class UAudioSourceDOT : MonoBehaviour
    {
        public abstract AudioSource AudioSource { get; set; }

        public abstract UnityEvent @Event { get; set; }
    }
}