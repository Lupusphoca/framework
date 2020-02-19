namespace Core.Helpers
{
    using System;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.Events;

    using Core.Enumerations;

    public class OnMouseClick : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] UnityEvent unityEvent;

        [SerializeField, Enum] MouseButtons.Buttons buttonsSelected;

        private void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                var flags = Enum.GetValues(typeof(MouseButtons.Buttons)).Cast<MouseButtons.Buttons>().Where(s => buttonsSelected.HasFlag(s));
                foreach (var value in flags)
                {
                    Debug.Log(value);
                }
            }
        }

        bool MouseClicked (int enumValue) //TODO Change this shitty fucking disguting code
        {
            switch (enumValue)
            {
                case -1:
                    if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
                    {
                        return true;
                    }
                    return false;
                case 1:
                    if (Input.GetMouseButtonDown(0))
                    {
                        return true;
                    }
                    return false;
                case 3:
                    if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                    {
                        return true;
                    }
                    return false;
                case 5:
                    if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(2))
                    {
                        return true;
                    }
                    return false;
                case 6:
                    if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
                    {
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }
    }
}
