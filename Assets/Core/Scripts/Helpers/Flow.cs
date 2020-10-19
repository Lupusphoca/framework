namespace PierreARNAUDET.Core.Helpers
{
    using PierreARNAUDET.Core.Attributes;
    using UnityEngine;
    using UnityEngine.Events;

    public class Flow : MonoBehaviour
    {
        [Events]
        [SerializeField] UnityEvent unityEvent;

        public void NextFlow()
        {
            unityEvent.Invoke();
        }
    }
}