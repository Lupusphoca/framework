namespace Core.Physics.Parabola
{
    using Core.ConditionalHide;
    using System.Collections.Generic;
    using UnityEngine;

    public class ParabolaProjectile : MonoBehaviour
    {
        float radianAngle;
        float angle;

        int dynamicVerticesNumber;
        public List<Vector3> curvePoints = new List<Vector3>();
        List<Vector3> previousFrameCurvePoints = new List<Vector3>();
        public List<Vector3> finalCurvePoints = new List<Vector3>();

        [Header("Required data")]
        [SerializeField] Transform transformLookingAt;

        [Header("Dynamic data")]
        [SerializeField] float velocity;
        [SerializeField] bool useSpecificVerticesAmount;
        [SerializeField, ConditionalHide("useSpecificVerticesAmount", false, true)] int verticesDivider;
        [SerializeField, ConditionalHide("useSpecificVerticesAmount")] int vertices;
        [SerializeField] float gravity = 9.81f;

        [Header("Optional data")]
        [SerializeField] Color gizmoColor;
        [SerializeField] float gizmoSize;

        public int Vertices
        {
            get
            {
                if (useSpecificVerticesAmount) { return vertices; }
                return dynamicVerticesNumber;
            }
        }

        void Update()
        {
            RenderLineArc();
            EtablishFinalCurvePoints();
        }

        /// <summary>
        /// Populating the curve with the appropriates settings
        /// </summary>
        void RenderLineArc()
        {
            angle = transformLookingAt.rotation.eulerAngles.z;
            dynamicVerticesNumber = SetDynamicNumberOfLineVertices();
            curvePoints = CalculateArcArray();
        }

        /// <summary>
        /// Dynamic set of the vertices numbers depending on the size of parabola (between first and last point)
        /// </summary>
        /// <returns>Return dynamic number of vertices used for curve</returns>
        int SetDynamicNumberOfLineVertices()
        {
            previousFrameCurvePoints = curvePoints;
            if (previousFrameCurvePoints.Count > 1)
            {
                var distanceBetweenCurvePole = (int)Vector3.Distance(previousFrameCurvePoints[0], previousFrameCurvePoints[previousFrameCurvePoints.Count - 1]);
                if (verticesDivider != 0)
                {
                    distanceBetweenCurvePole = distanceBetweenCurvePole / verticesDivider;
                }
                if (distanceBetweenCurvePole <= 2) { return 3; } //!3 is the default value to make it grow if dynamic vertices numbers isn't big enought
                return distanceBetweenCurvePole;
            }
            return 3;
        }

        /// <summary>
        /// Create a list of Vector3 positions for curve arc
        /// https://fr.wikipedia.org/wiki/Trajectoire_d%27un_projectile
        /// </summary>
        /// <returns>Return list of points</returns>
        List<Vector3> CalculateArcArray()
        {
            var arcArray = new List<Vector3>();
            curvePoints.Clear();

            radianAngle = Mathf.Deg2Rad * angle;
            var maximumDistance = (Mathf.Pow(velocity, 2f) * Mathf.Sin(2 * radianAngle)) / gravity;

            for (int i = 0; i <= Vertices; i++)
            {
                var radius = (float)i / (float)Vertices;
                arcArray.Add(CalculateArcPoint(radius, maximumDistance));
            }

            return arcArray;
        }

        /// <summary>
        /// Calculate height and distance of each vertex
        /// </summary>
        /// <param name="radius">Radius between origin point and new point</param>
        /// <param name="maximumDistance">Maximal radius, distance between origin point and last point</param>
        /// <returns>Return location of the point curve</returns>
        Vector3 CalculateArcPoint(float radius, float maximumDistance)
        {
            var x = radius * maximumDistance;
            var y = x * Mathf.Tan(radianAngle) - ((gravity * Mathf.Pow(x, 2)) / (2 * Mathf.Pow(velocity, 2) * Mathf.Pow(Mathf.Cos(radianAngle), 2)));
            var newPosition = new Vector3(x, y, 0) + transformLookingAt.position;
            return newPosition;
        }

        /// <summary>
        /// Finished to calculate curve points by including rotation around y.
        /// </summary>
        void EtablishFinalCurvePoints()
        {
            finalCurvePoints.Clear();

            for (int i = 0; i < curvePoints.Count; i++) //Process to move point around Y
            {
                var flatCenter = new Vector2(transformLookingAt.position.x, transformLookingAt.position.z);
                var flatAngle = transformLookingAt.rotation.eulerAngles.y;
                var pointTargeted = new Vector2(curvePoints[i].x, curvePoints[i].z);
                var flatRadius = Vector3.Distance(flatCenter, pointTargeted);
                var newFinalCurveFlatPoint = CalculateCoordinatesOnCircle(flatCenter, flatAngle, flatRadius);

                finalCurvePoints.Add(new Vector3(newFinalCurveFlatPoint.x, curvePoints[i].y, newFinalCurveFlatPoint.y));
            }
        }

        /// <summary>
        /// Used to find an other point on a circle depending of some settings
        /// </summary>
        /// <param name="center">Coordinates of the center of the circle</param>
        /// <param name="angle">Angle offset of new point</param>
        /// <param name="radius">Radius of the circle</param>
        /// <returns>Return coordinate of new point find</returns>
        Vector2 CalculateCoordinatesOnCircle(Vector2 center, float newAngle, float radius) //If used for floor referencial, it's X and Z you need to use in Unity
        {
            newAngle = Mathf.Deg2Rad * newAngle;
            var x = center.x + (radius * Mathf.Cos(newAngle));
            var z = center.y + (radius * Mathf.Sin(newAngle)) * -1;
            if (angle > 90f || angle < -90f)
            {
                x = -x;
                z = (center.y + (radius * Mathf.Sin(newAngle)));
            }
            return new Vector2(x, z);
        }

        /// <summary>
        /// Draw Gizmo on each point created for the curve
        /// </summary>
        void OnDrawGizmos()
        {
            for (int i = 0; i < finalCurvePoints.Count; i++)
            {
                var gizmoTransform = finalCurvePoints[i];
                Gizmos.color = gizmoColor;
                Gizmos.DrawSphere(gizmoTransform, gizmoSize);
            }
        }
    }
}