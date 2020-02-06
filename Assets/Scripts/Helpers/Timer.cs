namespace Core.Helpers
{
    using UnityEngine;

    using Core.Events;

    public class Timer : MonoBehaviour
    {
        float timer;
        bool timerActivate;

        [Header("Properties")]
        [SerializeField] float timerMultiplicator;

        public float TimerMultiplicator { get => timerMultiplicator; set { timerMultiplicator = value; } }

        [Header("Events")]
        [SerializeField] FloatEvent timerSpentEvent;

        private void FixedUpdate()
        {
            if (timerActivate)
            {
                timer += Time.fixedDeltaTime * timerMultiplicator;
                timerSpentEvent.Invoke(timer);
            }
        }

        public void StartTimer ()
        {
            timerActivate = true;
        }

        public void EndTimer ()
        {
            timerActivate = false;
        }

        public void ResetTimer ()
        {
            timer = 0f;
        }
    }
}
//TODO : Do a float scriptable model which you can reset or set the value in, and do a float incrementer that allow to increment that float. Create a "Timer" of that model and use it as a timer that you can use in your script