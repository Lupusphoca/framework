namespace PierreARNAUDET.Core.Helpers
{
    using NaughtyAttributes;
    using UnityEngine;
    using UnityEngine.Events;

    public class FlowSwitcher : MonoBehaviour
    {
        [Header ("Data")]
        [InfoBox("True = Open and False = Close")]
        [SerializeField] bool switcher;
        public bool Switcher { get => switcher; set => switcher = value; }

        [Header("Events")]
        [SerializeField] UnityEvent switchOpen;
        [SerializeField] UnityEvent switchClose;

        /// <summary>
        /// Change value of the switcher and ivoke event depending of this value
        /// </summary>
        public void CheckerSwitchState(bool @bool)
        {
            switcher = @bool;
            CheckerSwitchState();
        }

        /// <summary>
        /// Invoke event depending of the state of the referenced bool switcher
        /// </summary>
        public void CheckerSwitchState()
        {
            if (switcher) {
                switchOpen.Invoke();
            } else
            {
                switchClose.Invoke();
            }
        }
    }
}