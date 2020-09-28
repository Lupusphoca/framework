namespace PierreARNAUDET.Core.Maths
{
    using System;

    using UnityEngine;

    using PierreARNAUDET.Core.Events;

    public class AbsMath : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] IntEvent absoluteInt;
        [SerializeField] FloatEvent absoluteFloat;

        /// <summary>
        /// Return absolute value of a int in event
        /// </summary>
        /// <param name="value"></param>
        public void AbsInt(int value)
        {
            absoluteInt.Invoke(Math.Abs(value));
        }

        /// <summary>
        /// Return absolute value of a float in event
        /// </summary>
        /// <param name="value"></param>
        public void AbsFloat(float value)
        {
            absoluteFloat.Invoke(Math.Abs(value));
        }
    }
}