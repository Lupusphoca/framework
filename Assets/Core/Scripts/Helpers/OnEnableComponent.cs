namespace PierreARNAUDET.Core.Helpers
{
    using UnityEngine;
    using UnityEngine.Events;

    [DisallowMultipleComponent]
    class OnEnableComponent : MonoBehaviour
    {
        [SerializeField] UnityEvent onEnable;
        [SerializeField] UnityEvent onDisable;

        void OnEnable() => onEnable.Invoke();
        void OnDisable() => onDisable.Invoke();
    }
}