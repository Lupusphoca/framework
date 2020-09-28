namespace PierreARNAUDET.Core.Helpers
{
    using UnityEngine;
    using UnityEngine.Events;

    [DisallowMultipleComponent]
    public class OnKeyPressed : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] KeyCode keyCode;
        public KeyCode KeyCode { get => keyCode; set => keyCode = value; }

        [Header("Events")]
        [SerializeField] UnityEvent unityEvent;

        /// <summary>
        /// Verify if referenced keycode was down to invoke event
        /// </summary>
        public void GetKeyDown()
        {
            if (Input.GetKeyDown (keyCode))
            {
                unityEvent.Invoke();
            }
        }
    }
}