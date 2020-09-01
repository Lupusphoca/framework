namespace Core.Complexes.Mathematics.Parabola
{
    using System.Collections.Generic;
    using UnityEngine;

    using Core.ConditionalHide;

    public class ProjectileMotionParabolaEquation : UParabolaEquation
    {
        [Header("Required data")]
        [SerializeField] bool useFixNumberVertices;
        [SerializeField, ConditionalHide("useFixNumberVertices", false, false)] int fixNumberVertices;
        [SerializeField, ConditionalHide("useFixNumberVertices", false, true)] int verticesDivider;
        [SerializeField] float gravity;
        [SerializeField] float velocity;
        [SerializeField] Transform transformLookingAt;
        
        int maximumDistance;
        float previousFrameAngleAtMaximumDistance;
        
        List<Vector3> previousFramePlanarCurvePoint;
        List<Vector3> planarCurvePoint;
        List<Vector3> spatialCurvePoint;

        public override bool UseFixNumberVertices { get => useFixNumberVertices; set => useFixNumberVertices = value; }
        public override int FixNumberVertices { get => fixNumberVertices; set => fixNumberVertices = value; }
        public override int VerticesDivider { get => verticesDivider; set => verticesDivider = value; }
        public override float AngleAroundAxisZ { get => transformLookingAt.eulerAngles .z; } //! Use rotation around Z of TransformLookingAt
        public override List<Vector3> PreviousFramePlanarCurvePoint { get => previousFramePlanarCurvePoint; set => previousFramePlanarCurvePoint = value; }
        public override List<Vector3> PlanarCurvePoint { get => planarCurvePoint; set => planarCurvePoint = value; }
        public override List<Vector3> SpatialCurvePoint { get => spatialCurvePoint; set => spatialCurvePoint = value; }
        public override Transform TransformLookingAt { get => transformLookingAt; set => transformLookingAt = value; }
        public override int MaximumDistance { get => maximumDistance; set => maximumDistance = value; }
        public override float PreviousFrameAngleAtMaximumDistance { get => previousFrameAngleAtMaximumDistance; set => previousFrameAngleAtMaximumDistance = value; }

        public override Vector3 CalculateArcPoint(int verticeID)
        {
            var radius = (float)verticeID / (float)Vertices;
            var radianAngle = Mathf.Deg2Rad * AngleAroundAxisZ;

            maximumDistance = (int)CalculateDynamicMaximumDistance(radianAngle);

            var x = radius * maximumDistance;
            if (Mathf.Cos(radianAngle) < 0) { x = -x; }
            var y = x * Mathf.Tan(radianAngle) - ((gravity * Mathf.Pow(x, 2)) / (2 * Mathf.Pow(velocity, 2) * Mathf.Pow(Mathf.Cos(radianAngle), 2)));

            var newPosition = new Vector3(x, y, 0) + transformLookingAt.position;
            return newPosition;
        } 

        /// <summary>
        /// Calculate maximum distance needed to avoid a too much big value based on trigonometric calculation : https://fr.wikipedia.org/wiki/Cercle_trigonom%C3%A9trique
        /// </summary>
        /// <param name="radianAngle">Radian angle used to do trigonometric calculation</param>
        /// <returns>Maximum distance of the curve</returns>
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
    }
}