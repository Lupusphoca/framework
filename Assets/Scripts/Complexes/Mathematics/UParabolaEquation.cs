namespace Core.Complexes.Mathematics.Parabola
{
    using System.Collections.Generic;
    using UnityEngine;

    using Core.Events;

    public abstract class UParabolaEquation : MonoBehaviour
    {
        [Header ("Flow")]
        [SerializeField] Vector3ListEvent vector3ListUnityEvent;

        public abstract bool UseFixNumberVertices { get; set; }
        public abstract int FixNumberVertices { get; set; }
        public abstract int VerticesDivider { get; set; }

        public abstract int MaximumDistance { get; set; }

        public abstract float PreviousFrameAngleAtMaximumDistance { get; set; }
        public abstract float AngleAroundAxisZ { get; }

        public abstract List<Vector3> PreviousFramePlanarCurvePoint { get; set; }
        public abstract List<Vector3> PlanarCurvePoint { get; set; }
        public abstract List<Vector3> SpatialCurvePoint { get; set; }
        public abstract Transform TransformLookingAt { get; set; }


        public virtual void Awake() //! Initialize variables used in script with a default value
        {
            PreviousFramePlanarCurvePoint = new List<Vector3>();
            PlanarCurvePoint = new List<Vector3>();
            SpatialCurvePoint = new List<Vector3>();
            MaximumDistance = 10;
        }

        /// <summary>
        /// Dynamic set of the vertices numbers depending on the size of parabola (between first and last point)
        /// </summary>
        /// <returns>Return dynamic number of vertices used for curve</returns>
        public int Vertices
        {
            get
            {
                if (UseFixNumberVertices) { return FixNumberVertices; }
                if (PreviousFramePlanarCurvePoint.Count > 1)
                {
                    var distanceBetweenCurvePole = (int)Vector3.Distance(PreviousFramePlanarCurvePoint[0], PreviousFramePlanarCurvePoint[PreviousFramePlanarCurvePoint.Count - 1]);
                    if (VerticesDivider > 0)
                    {
                        distanceBetweenCurvePole = distanceBetweenCurvePole / VerticesDivider;
                    }
                    if (distanceBetweenCurvePole <= 2) { return 3; } //!3 is the default value to make it grow if dynamic vertices numbers isn't big enought
                    return distanceBetweenCurvePole;
                }
                return 3;
            }
        }

        private void FixedUpdate()
        {
            PlanarCurvePoint = CalculateArcArray();
            CalculateDynamicMaximumDistance(PlanarCurvePoint.ToArray());
            CalculateRotationAroundY();
            vector3ListUnityEvent.Invoke(SpatialCurvePoint);
            
        }

        /// <summary>
        /// Create a list of Vector3 positions for curve arc by using CalculateArcPoint function
        /// https://fr.wikipedia.org/wiki/Trajectoire_d%27un_projectile
        /// </summary>
        /// <returns>Return list of points</returns>
        public virtual List<Vector3> CalculateArcArray()
        {
            var arcArray = new List<Vector3>();
            PreviousFramePlanarCurvePoint = PlanarCurvePoint;
            arcArray.Clear();

            for (int i = 0; i <= Vertices; i++)
            {
                arcArray.Add(CalculateArcPoint(i));
            }

            return arcArray;
        }

        /// <summary>
        /// Change dynamicly the maximum distance by calculating angle between last points n and n-1
        /// </summary>
        /// <param name="listPoints">List of points used for the calculation</param>
        public virtual void CalculateDynamicMaximumDistance(Vector3[] listPoints) 
        {
            //TODO Try to make that it cost less calculation and stop oscillating between else and if state
           /* if (Vertices > 2 && listPoints.Length > 2)
            {
                var u = new Vector2(Mathf.Abs(listPoints[Vertices].x), Mathf.Abs(listPoints[Vertices].y));
                var v = new Vector2(Mathf.Abs(listPoints[Vertices - 1].x), Mathf.Abs(listPoints[Vertices - 1].y));
                var newU = new Vector2(1, 0);
                var newV = u - v;
                var radianAtMaximumDistance = Mathf.Acos(Vector3.Dot(newU, newV) / (newU.magnitude * newV.magnitude));

                var angleAtMaximumDistance = radianAtMaximumDistance * Mathf.Rad2Deg;
                Debug.Log($"Angle between two last points curve : {angleAtMaximumDistance}, ");
                if (angleAtMaximumDistance < 80f)
                {
                    MaximumDistance += 1;
                }
                if (PreviousFrameAngleAtMaximumDistance > angleAtMaximumDistance)
                {
                    if (angleAtMaximumDistance > 80f)
                    {
                        MaximumDistance -= 1;
                    }
                }
                Debug.Log($"Temp maxDis : {MaximumDistance}");
                PreviousFrameAngleAtMaximumDistance = angleAtMaximumDistance;
            }*/
        }

        /// <summary>
        /// Calculate height and distance of each vertex
        /// </summary>
        /// <returns>Return location of curve point </returns>
        public abstract Vector3 CalculateArcPoint(int verticeID);

        /// <summary>
        /// Finished to calculate curve points by including rotation around y by using CalculateCoordinatesOnCircle function
        /// </summary>
        public virtual void CalculateRotationAroundY() //EtablishFinalCurvePoints 
        {
            SpatialCurvePoint.Clear();

            for (int i = 0; i < PlanarCurvePoint.Count; i++) //Process to move point around Y
            {
                var flatCenter = new Vector2(TransformLookingAt.position.x, TransformLookingAt.position.z);
                var flatAngle = TransformLookingAt.rotation.eulerAngles.y;
                var pointTargeted = new Vector2(PlanarCurvePoint[i].x, PlanarCurvePoint[i].z);
                var flatRadius = Vector3.Distance(flatCenter, pointTargeted);
                var newFinalCurveFlatPoint = CalculateCoordinatesOnCircle(flatCenter, flatAngle, flatRadius);

                SpatialCurvePoint.Add(new Vector3(newFinalCurveFlatPoint.x, PlanarCurvePoint[i].y, newFinalCurveFlatPoint.y));
            }
        }

        /// <summary>
        /// Used to find an other point on a circle depending of some settings
        /// </summary>
        /// <param name="center">Coordinates of the center of the circle</param>
        /// <param name="angle">Angle offset of new point</param>
        /// <param name="radius">Radius of the circle</param>
        /// <returns>Return coordinate of new point find</returns>
        Vector2 CalculateCoordinatesOnCircle(Vector2 center, float angleAroundY, float radius) //If used for floor referencial, it's X and Z you need to use in Unity
        {
            var newRadianAngleAroundZ = Mathf.Deg2Rad * AngleAroundAxisZ;
            var newRadianAngleAroundY = Mathf.Deg2Rad * angleAroundY;
            var x = center.x + (radius * Mathf.Cos(newRadianAngleAroundY));
            var z = center.y + (radius * Mathf.Sin(newRadianAngleAroundY)) * -1;
            if (Mathf.Cos(newRadianAngleAroundZ) < 0)
            {
                x = center.x + (radius * Mathf.Cos(newRadianAngleAroundY)) * -1;
                z = center.y + (radius * Mathf.Sin(newRadianAngleAroundY));
            }
            return new Vector2(x, z);
        }
    }
}
