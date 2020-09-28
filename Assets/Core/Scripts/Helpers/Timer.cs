namespace PierreARNAUDET.Core.Helpers
{
    using UnityEngine;

    using PierreARNAUDET.Core.Events;

    public class Timer : MonoBehaviour
    {
        float timer;
        bool timerState;

        [Header("Settings")]
        [SerializeField] float timerMultiplicator;
        public float TimerMultiplicator { get => timerMultiplicator; set { timerMultiplicator = value; } }

        [Header("Events")]
        [SerializeField] FloatEvent timerSpentEvent;

        private void FixedUpdate()
        {
            if (timerState)
            {
                timer += Time.fixedDeltaTime * timerMultiplicator;
                timerSpentEvent.Invoke(timer);
            }
        }

        /// <summary>
        /// Assign a new state to timer state
        /// </summary>
        /// <param name="newState">New timer state</param>
        public void SwitchTimerState (bool newState) => timerState = newState;

        /// <summary>
        /// Invert timer state
        /// </summary>
        public void SwitchTimerState() => timerState = !timerState;

        public void ResetTimer() => timer = 0f;
    }
}
//TODO : Do a float scriptable model which you can reset or set the value in, and do a float incrementer that allow to increment that float. Create a "Timer" of that model and use it as a timer that you can use in your script