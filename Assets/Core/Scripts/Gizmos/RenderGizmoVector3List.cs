namespace PierreARNAUDET.Core.Gizmos
{
    using System.Collections.Generic;
    using UnityEngine;

    public class RenderGizmoVector3List : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] List<Vector3> listVector3 = new List<Vector3>();
        public List<Vector3> ListVector3 {get => listVector3; set => listVector3 = value; }

        [Header("Settings")]
        [SerializeField] Color gizmoColor;
        [SerializeField] float gizmoSize;


        /// <summary>
        /// Draw Gizmo for each point of the list
        /// </summary>
        void OnDrawGizmos()
        {
            for (int i = 0; i < listVector3.Count; i++)
            {
                var gizmoTransform = listVector3[i];
                Gizmos.color = gizmoColor;
                Gizmos.DrawSphere(gizmoTransform, gizmoSize);
            }
        }

        //public void Reset() => listVector3.Clear();
        //TODO This function make the whole system crash because she act like a pointer ! Why ?
    }
}