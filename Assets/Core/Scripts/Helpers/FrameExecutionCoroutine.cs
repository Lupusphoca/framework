namespace PierreARNAUDET.Core.Helpers
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Events;

    public class FrameExecutionCoroutine : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField, Range(0.01f, 10f)] float frequencePerSecond;

        [Header("Events")]
        [SerializeField] UnityEvent unityEvent;

        /// <summary>
        /// Start the coroutine frame execution
        /// </summary>
        public void StartFrameExecution()
        {
            StartCoroutine(Execution());
        }

        IEnumerator Execution ()
        {
            yield return new WaitForSeconds(frequencePerSecond);
            unityEvent.Invoke();
            StartCoroutine(Execution());
        }
    }
}