namespace Core.Helpers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    using Core.Enumerations;

    public class OnMouseClick : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] UnityEvent unityEvent;

        [SerializeField, Enum] MouseButtons.Buttons buttonsSelected;
        List<int> buttonsCode = new List<int>();

        private void Start()
        {
            GetIntEnumSelected();
        }

        void GetIntEnumSelected()
        {
            var mouseButtons = new MouseButtons();
            var flags = Enum.GetValues(typeof(MouseButtons.Buttons)).Cast<MouseButtons.Buttons>().Where(s => buttonsSelected.HasFlag(s));
            foreach (MouseButtons.Buttons value in flags)
            {
                buttonsCode.Add(mouseButtons.GetValue(value)); 
            }
        }

        private void FixedUpdate()
        {
            if (Input.anyKeyDown)
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
}
