namespace PierreARNAUDET.Core.Mathematics
{
    using UnityEngine;

    using PierreARNAUDET.Core.Events;

    public class IntRatioPourcentage : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] float maximumValueForRatioCalculation;

        [Header("Events")] 
        [SerializeField] FloatEvent ratioEvent;

        public void CalculateRatioValue(int value)
        {
            float ratio = value / maximumValueForRatioCalculation;
            ratioEvent.Invoke(ratio);
        }
    }
}