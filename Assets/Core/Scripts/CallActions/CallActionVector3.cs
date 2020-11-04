namespace PierreARNAUDET.Core.CallActions
{
    using UnityEngine;

    using PierreARNAUDET.Core.Attributes;
    using PierreARNAUDET.Core.Events;

    public class CallActionVector3 : MonoBehaviour
    {
        [Data]
        [SerializeField] Vector3 vector3;
        public Vector3 Vector3 { get => vector3; set => vector3 = value; }

        [Events]
        [SerializeField] Vector3Event modifiedVector3;

        #region Modify values
        public void ModifyXValue (float newValue)
        {
            vector3.x = newValue;
            modifiedVector3.Invoke(vector3);
        }

        public void ModifyXValue(int newValue)
        {
            vector3.x = newValue;
            modifiedVector3.Invoke(vector3);
        }

        public void ModifyYValue(float newValue)
        {
            vector3.y = newValue;
            modifiedVector3.Invoke(vector3);
        }

        public void ModifyYValue(int newValue)
        {
            vector3.y = newValue;
            modifiedVector3.Invoke(vector3);
        }

        public void ModifyZValue(float newValue)
        {
            vector3.z = newValue;
            modifiedVector3.Invoke(vector3);
        }

        public void ModifyZValue(int newValue)
        {
            vector3.z = newValue;
            modifiedVector3.Invoke(vector3);
        }
        #endregion
    }
}