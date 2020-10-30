namespace PierreARNAUDET.Modules.DOT.AudioSources
{
    using UnityEngine;
    using UnityEngine.Events;

    public abstract class UAudioSourceDOT : MonoBehaviour
    {
        public abstract AudioSource AudioSource { get; set; }

        public abstract UnityEvent @Event { get; set; }
    }
}