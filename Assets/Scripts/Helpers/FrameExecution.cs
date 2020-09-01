namespace Core.Helpers
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Events;

    public class FrameExecution : MonoBehaviour
    {
        [Header("Required data")]
        [SerializeField, Range(0.01f, 10f)] float frequencePerSecond;

        [Header("Out flow")]
        [SerializeField] UnityEvent unityEvent;

        private void Start()
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