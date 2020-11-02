namespace PierreARNAUDET.Modules.DOT.Sliders
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    public abstract class USliderDOT : MonoBehaviour
    {
        public abstract Slider Slider { get; set; }

        public abstract UnityEvent @Event { get; set; }
    }
}