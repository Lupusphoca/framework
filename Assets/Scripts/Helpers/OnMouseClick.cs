namespace Core.Helpers
{
    using UnityEngine;
    using UnityEngine.Events;
    using System.Collections.Generic;

    using Core.Enumerations;

    public class OnMouseClick : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] UnityEvent unityEvent;

        /*[System.Flags] enum MouseButtons { Left, Right, Middle }
        [EnumAttribute] MouseButtons GetMouseButtons;

        List<int> ReturnSelectedElements ()
        {
            List<int> selectedElements = new List<int>();
            for (int i = 0; i < System.Enum.GetValues(typeof(MouseButtons)).Length; i++)
            {
                int layer = 1 << i;
                if (((int)GetMouseButtons & layer) != 0)
                {
                    selectedElements.Add(i);
                }
            }
            return selectedElements;
        }*/

        [SerializeField, EnumAttribute] MouseButtons mouseButtons;

        private void FixedUpdate()
        {
            Debug.Log($"mouse buttons {(int)mouseButtons}");
           /* if (Input.GetMouseButtonDown((int)mouseButtons))
            unityEvent.Invoke();*/
        }
    }
}
