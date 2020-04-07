namespace Core.Complexes
{
    using System.Collections.Generic;
    using UnityEngine;

    public class RenderGizmoVector3List : MonoBehaviour
    {
        [Header("Dynamic data")]
        [SerializeField] List<Vector3> listVector3 = new List<Vector3>();

        [Header("Gizmo display")]
        [SerializeField] Color gizmoColor;
        [SerializeField] float gizmoSize;

        public List<Vector3> ListVector3 {get => listVector3; set => listVector3 = value; }

        /// <summary>
        /// Draw Gizmo on each point created for the curve
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
    }
}