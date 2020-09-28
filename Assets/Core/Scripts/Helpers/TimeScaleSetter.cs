namespace PierreARNAUDET.Core.Helpers
{
    using UnityEngine;

    public class TimeScaleSetter : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] float timeScale;
        public float TimeScale { get => timeScale; set => timeScale = value; }

        /// <summary>
        /// Set time scale
        /// </summary>
        public void SetTimeScale()
        {
            Time.timeScale = timeScale;
        }

        /// <summary>
        /// Set time scale
        /// </summary>
        /// <param name="newTimeScale">New time scale value</param>
        public void SetTimeScale (float newTimeScale)
        {
            Time.timeScale = newTimeScale;
        }
    }
}