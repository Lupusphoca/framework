namespace PierreARNAUDET.Core.Helpers
{
    using UnityEngine;
    using UnityEngine.Events;

    [DisallowMultipleComponent]
    class OnDestroyComponent : MonoBehaviour
    {
        [SerializeField]
        UnityEvent onDestroy;

        private void OnDestroy() => onDestroy.Invoke();
    }
}
