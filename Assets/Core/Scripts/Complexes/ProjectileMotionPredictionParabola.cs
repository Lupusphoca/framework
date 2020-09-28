namespace PierreARNAUDET.Core.Complexes.Mathematics.Parabola
{
    using System.Collections.Generic;
    using UnityEngine;

    using PierreARNAUDET.Core.Events;

    public class ProjectileMotionPredictionParabola : MonoBehaviour
    {
        List<Vector3> curvePoints = new List<Vector3>();
        Vector3 gravity = new Vector3(0, -9.81f, 0);
        Vector3 initialVelocity;

        [Header ("Data")]
        [SerializeField] Transform initialPoint;
        public Transform InitialPoint { get => initialPoint; set => initialPoint = value; }
        [SerializeField] Transform directionalPoint;
        public Transform DirectionalPoint { get => directionalPoint; set => directionalPoint = value; }

        [Header("Settings")]
        [SerializeField] float velocityMultiplier;
        [SerializeField] int maximumPoints;
        [SerializeField] float pointFrequence;

        [Header("Events")]
        [SerializeField] Vector3ListEvent listVector3Event;

        public float VelocityMultiplier { get => velocityMultiplier; set => velocityMultiplier = value; }

        public void CalculatePointArray()
        {
            initialVelocity = directionalPoint.position - initialPoint.position;
            initialVelocity *= velocityMultiplier;

            curvePoints.Clear();
            for (int i = 0; i < maximumPoints; i++)
            {
                float time = (float)i * pointFrequence;
                Vector3 x = PredictProjectileAtTime(time, initialVelocity, initialPoint.position);
                curvePoints.Add(x);
            }
            listVector3Event.Invoke(curvePoints);
        }

        Vector3 PredictProjectileAtTime(float t, Vector3 v0, Vector3 x0)
        {
            return gravity * (0.5f * Mathf.Pow(t, 2f)) + v0 * t + x0;
        }
    }
}