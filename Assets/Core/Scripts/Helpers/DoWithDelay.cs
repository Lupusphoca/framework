namespace PierreARNAUDET.Core.Helpers
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Events;

    public class DoWithDelay : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField, Range(0.01f, 10f)] float timeToWait;

        [Header("Events")]
        [SerializeField] UnityEvent beforeWaitingTime;
        [SerializeField] UnityEvent afterWaitingTime;

        /// <summary>
        /// Start delay before executing end event
        /// </summary>
        public void StartDelay()
        {
            beforeWaitingTime.Invoke();
            StartCoroutine(Execution());
        }

        IEnumerator Execution ()
        {
            yield return new WaitForSeconds(timeToWait);
            afterWaitingTime.Invoke();
        }
    }
}