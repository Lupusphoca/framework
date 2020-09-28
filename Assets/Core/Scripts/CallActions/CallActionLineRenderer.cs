namespace PierreARNAUDET.Core.CallActions
{
    using System.Collections.Generic;
    using UnityEngine;

    public class CallActionLineRenderer : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] LineRenderer lineRenderer;
        public LineRenderer LineRenderer { get => lineRenderer; set => lineRenderer = value; }

        #region Positions
        List<Vector3> listPositions = new List<Vector3>();

        [Header("Data : Positions")]
        [SerializeField] Transform firstPoint;
        public Transform FirstPoint { get => firstPoint; set => firstPoint = value; }

        /// <summary>
        /// Set a new list of points in the LineRenderer
        /// </summary>
        /// <param name="newVector3Array">Array of points</param>
        public void SetNewPositions(Vector3[] newVector3Array)
        {
            if (lineRenderer.positionCount != newVector3Array.Length + 1)
            {
                lineRenderer.positionCount = newVector3Array.Length + 1;
            }

            listPositions.Clear();
            listPositions.Add(firstPoint.position);
            listPositions.AddRange(newVector3Array);

            lineRenderer.SetPositions(listPositions.ToArray());
        }

        /// <summary>
        /// Clear the whole line renderer list of points
        /// </summary>
        public void ClearPositions()
        {
            lineRenderer.positionCount = 0;
        }
        #endregion
    }
}