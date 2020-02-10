namespace Core.Helpers
{
    using System;
    using UnityEngine;
    using UnityEngine.Events;

    using Core.Enumerations;

    public class OnMouseClick : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] UnityEvent unityEvent;

        [SerializeField, Enum] MouseButtons buttonsSelected;

        private void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                foreach (MouseButtons button in Enum.GetValues(typeof(MouseButtons)))
                {
                    if(buttonsSelected.HasFlag(button))
                    {
                        Debug.Log(button);
                    }
                }
            }

            if (MouseClicked((int)buttonsSelected))
            {
                unityEvent.Invoke();
            }
        }

        bool MouseClicked (int enumValue) //TODO Change this shitty fuckibg disguting code
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
