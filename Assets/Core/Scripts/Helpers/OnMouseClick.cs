namespace PierreARNAUDET.Core.Helpers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Enumerations;

    public class OnMouseClick : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] UnityEvent unityEvent;

        [SerializeField, Enum] ButtonEnum.Buttons buttonsSelected;
        List<int> buttonsCode = new List<int>();

        void Start()
        {
            GetIntEnumSelected();
        }

        void GetIntEnumSelected()
        {
            var mouseButtons = new ButtonEnum();
            var flags = Enum.GetValues(typeof(ButtonEnum.Buttons))
                .Cast<ButtonEnum.Buttons>()
                .Where(s => buttonsSelected.HasFlag(s));
            foreach (ButtonEnum.Buttons value in flags)
            {
                buttonsCode.Add(mouseButtons.GetValue(value)); 
            }
        }

        /// <summary>
        /// Verify if mouse button was clicked to invoke evnet
        /// </summary>
        public void GetMouseClick()
        {
            var buttonsCodeSize = buttonsCode.Count();
            for (int i = 0; i < buttonsCodeSize; i++)
            {
                var codeButton = buttonsCode[i];
                if (Input.GetMouseButtonDown(codeButton))
                {
                    unityEvent.Invoke();
                }
            }
        }
    }
}
