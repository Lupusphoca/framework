namespace PierreARNAUDET.Core.Complexes.Obsolete
{
    using System.Collections.Generic;
    using UnityEngine;

    [RequireComponent(typeof(LineRenderer))]
    public class LineRendererCurveSystem : MonoBehaviour //! Script only used to make some test, he's useless because doing the same thing than ProjectileMotionParabolaEquation.
    {
        float radianAngle;
        List<Vector3> PlanarCurvePoint = new List<Vector3>();
        List<Vector3> SpatialCurvePoint = new List<Vector3>();

        [Header ("Required data")]
        [SerializeField] LineRenderer lr;
        [SerializeField] float velocity;
        [SerializeField] int resolution;
        [SerializeField] float gravity;

        [Header("Dynamic data")]
        [SerializeField] float angleZ;
        [SerializeField] float angleY;
        [SerializeField] float startPointPositionX;
        [SerializeField] float startPointPositionY;
        [SerializeField] float startPointPositionZ;

        public float AngleZ { get => angleZ; set => angleZ = value; }
        public float AngleY { get => angleY; set => angleY = value; }
        public float StartPointPositionX { get => startPointPositionX; set => startPointPositionX = value; }
        public float StartPointPositionY { get => startPointPositionY; set => startPointPositionY = value; }
        public float StartPointPositionZ { get => startPointPositionZ; set => startPointPositionZ = value; }

        private void OnValidate()
        {
            if (lr != null && Application.isPlaying && resolution > 0)
            {
                RenderArc();
            }
        }

        private void FixedUpdate()
        {
            if (resolution > 0 && lr != null) {
                RenderArc();
                for (int i = 0; i < lr.positionCount; i++)
                {
                    PlanarCurvePoint.Add(lr.GetPosition(i));
                }
                CalculateRotationAroundY();
                lr.SetPositions(SpatialCurvePoint.ToArray());
                PlanarCurvePoint.Clear();
            }
        }

        void RenderArc()
        {
            lr.positionCount = resolution + 1;
            lr.SetPositions(CalculateArcArray());
        }

        Vector3[] CalculateArcArray()
        {
            Vector3[] arcArray = new Vector3[resolution + 1];
            radianAngle = Mathf.Deg2Rad * AngleZ;

            float maxDistance = (int)CalculateDynamicMaximumDistance(radianAngle);
            //float maxDistance = Mathf.Pow(velocity,2) * Mathf.Sin(2 * radianAngle) / gravity;

            for (int i = 0; i <= resolution; i ++)
            {
                float t = (float)i / (float)resolution;
                arcArray[i] = CalculateArcPoint(t, maxDistance);
            }
            return arcArray;
        }

        Vector3 CalculateArcPoint (float t, float maxDistance)
        {
            float x = t * maxDistance;
            if (Mathf.Cos(radianAngle) < 0) { x = -x; }
            float y = x * Mathf.Tan(radianAngle) - ((gravity * Mathf.Pow(x, 2)) / (2 * Mathf.Pow(velocity, 2) * Mathf.Pow(Mathf.Cos(radianAngle), 2)));
            return new Vector3(x + StartPointPositionX, y + StartPointPositionY, StartPointPositionZ);
        }

        public float CalculateDynamicMaximumDistance(float radianAngle)
        {
            var newMaximumDistance = (Mathf.Pow(velocity, 2) / gravity);

            if (Mathf.PI < radianAngle && radianAngle < 2 * Mathf.PI) //!If all parabola x values are under 0 (x<0) then we reduce maximumDistance size to avoid useless vertices.
            {
                var maximumDistanceDivider = (Mathf.PI / Mathf.Abs(((3 * Mathf.PI) / 2) - radianAngle));
                return (newMaximumDistance / maximumDistanceDivider) * 8;
            }

            else if (1.92f > radianAngle && radianAngle > 1.22f)
            {
                var maximumDistanceDivider = ((1f / Mathf.PI) / Mathf.Abs((Mathf.PI / 2) - radianAngle));
                return newMaximumDistance / maximumDistanceDivider;
            }
            var multiple = 1 / ((1f / Mathf.PI) / Mathf.Abs((Mathf.PI / 2) - radianAngle));
            return newMaximumDistance * multiple;
        }

        public virtual void CalculateRotationAroundY()
        {
            SpatialCurvePoint.Clear();

            for (int i = 0; i < PlanarCurvePoint.Count; i++) //Process to move point around Y
            {
                var flatCenter = new Vector2(StartPointPositionX, StartPointPositionZ);
                var pointTargeted = new Vector2(PlanarCurvePoint[i].x, PlanarCurvePoint[i].z);
                var flatRange = Vector3.Distance(flatCenter, pointTargeted);
                var newFinalCurveFlatPoint = CalculateCoordinatesOnCircle(flatCenter, flatRange);

                SpatialCurvePoint.Add(new Vector3(newFinalCurveFlatPoint.x, PlanarCurvePoint[i].y, newFinalCurveFlatPoint.y));
            }
        }

        Vector2 CalculateCoordinatesOnCircle(Vector2 center, float range) //If used for floor referencial, it's X and Z you need to use in Unity
        {
            var newRadianAngleAroundZ = Mathf.Deg2Rad * AngleZ;
            var newRadianAngleAroundY = Mathf.Deg2Rad * AngleY;
            var x = center.x + (range * Mathf.Cos(newRadianAngleAroundY));
            var z = center.y + (range * Mathf.Sin(newRadianAngleAroundY)) * -1;
            if (Mathf.Cos(newRadianAngleAroundZ) < 0)
            {
                x = center.x + (range * Mathf.Cos(newRadianAngleAroundY)) * -1;
                z = center.y + (range * Mathf.Sin(newRadianAngleAroundY));
            }
            return new Vector2(x, z);
        }
    }
}