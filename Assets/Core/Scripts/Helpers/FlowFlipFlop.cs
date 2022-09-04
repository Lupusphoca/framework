namespace PierreARNAUDET.Core.Helpers
{
    using UnityEngine;
    using UnityEngine.Events;

    public class FlowFlipFlop : MonoBehaviour
    {
        [SerializeField] bool executeFlip;

        [Header("Events")]
        [SerializeField] UnityEvent flipEvent;
        [SerializeField] UnityEvent flopEvent;

        public void FlipFlopEvent ()
        {
            switch (executeFlip)
            {
                case true:
                    flipEvent.Invoke();
                    executeFlip = !executeFlip;
                    break;
                case false:
                    flopEvent.Invoke();
                    executeFlip = !executeFlip;
                    break;
            }
        }
    }
}
