namespace PierreARNAUDET.Core.Complexes
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Events;

    public class MoveObjectOnParabola : MonoBehaviour
    {
        bool moveObject;
        int count;
        Vector3 previousPoint;
        Vector3 nextPoint;
        float longestVertex;
        float actualVertex;
        float dynamicSpeed;
        float dynamicAcceptanceRange;
        float velocityThrow;
        public float VelocityThrow { get => velocityThrow; set => velocityThrow = value; }

        RaycastHit raycastHit;
        bool doesRaycastHitObject;
        Vector3 hittedPoint;
        Vector3 extremumVector;
        int extremumParabola;

        [Header("Data")]
        [SerializeField] List<Vector3> pointsToParse;
        public List<Vector3> PointsToParse { get => pointsToParse; set => pointsToParse = value; }
        [SerializeField] Transform transformToMove;
        public Transform TransformToMove { get => transformToMove; set => transformToMove = value; }

        [Header ("Settings")]
        [SerializeField, Range(0.01f, 1f)] float acceptanceRange;
        [SerializeField, Range(1, 50)] float speedDivisorAscend;
        [SerializeField, Range(1, 50)] float speedDivisorDescend;
        [SerializeField, Range(1, 50)] float maximumSpeed;
        [SerializeField, Range(0, 1)] float minimumSpeed;
        [SerializeField, Range(0, 1)] float baseMinimumSpeed;
        [SerializeField, Range(-1, 1)] float altitudeInfluence;

        [Header("Events")]
        [SerializeField] Vector3Event nextPointDestination;
        [SerializeField] UnityEvent lastPointReached;
        [SerializeField] Vector3Event reachedTeleportationPoint;

        public void ParseObjectAlongParabola()
        {
            moveObject = true;
            count = 0;
            previousPoint = transformToMove.position;
            longestVertex = Vector3.Distance(pointsToParse[0], pointsToParse[1]);
            nextPoint = pointsToParse[0];
            extremumParabola = GetExtremumValue(pointsToParse);
            CheckCollisionBetweenPoints(1);
        }

        public void FixedUpdate()
        {
            if (moveObject && !doesRaycastHitObject)
            {
                MoveTowardsNextPoint();
            }
            if (doesRaycastHitObject)
            {
                MoveTowardsTeleportationPoint();
            }
        }

        /// <summary>
        /// Set points to parse list with a function to avoid automatical link reference with list shared
        /// </summary>
        /// <param name="points">List of points that object while parse</param>
        public void SetPointsToParse(List<Vector3> points)
        {
            pointsToParse.Clear();
            for (int i = 0; i < points.Count; i++)
            {
                pointsToParse.Add(points[i]);
            }
        }

        #region Speed calculation
        int GetExtremumValue(List<Vector3> listVector3)
        {
            var extremum = 0;
            for (int i = 1; i < listVector3.Count; i++)
            {
                if (listVector3[i].y > listVector3[extremum].y)
                {
                    extremumVector = listVector3[extremum];
                    extremum = i;
                }
            }
            return extremum;
        }

        float GetYDifference(Vector3 point, Vector3 extremum)
        {
            float difference = extremum.y - point.y;
            return difference;
        }

        float CalculateDynamicSpeed(Vector3 vectorExtremum)
        {
            float modifySpeed;
            int extremumPoint = GetExtremumValue(pointsToParse);
            float yDifference = GetYDifference(pointsToParse[0], pointsToParse[extremumPoint]);

            if (extremumParabola > count)
            {
                modifySpeed = ((1 / (longestVertex / actualVertex)) * Vector3.Distance(TransformToMove.position, extremumVector)) / speedDivisorAscend;
                if (modifySpeed <= (baseMinimumSpeed + yDifference*altitudeInfluence))
                {
                    modifySpeed = baseMinimumSpeed + yDifference * altitudeInfluence;

                    if(modifySpeed < minimumSpeed)
                    {
                        modifySpeed = minimumSpeed;
                    }
                }
                else
                {
                    modifySpeed = ((1 / (longestVertex / actualVertex)) * Vector3.Distance(TransformToMove.position, extremumVector)) / speedDivisorAscend;
                }
            }
            else
            {
                modifySpeed = ((1 / (longestVertex / actualVertex)) * Vector3.Distance(TransformToMove.position, extremumVector)) / speedDivisorDescend;
                if (modifySpeed <= (baseMinimumSpeed + yDifference * altitudeInfluence))
                {
                    modifySpeed = baseMinimumSpeed + yDifference * altitudeInfluence;

                    if (modifySpeed < minimumSpeed)
                    {
                        modifySpeed = minimumSpeed;
                    }

                    if (modifySpeed > maximumSpeed)
                    {
                        modifySpeed = maximumSpeed;
                    }
                }
                else
                {
                    modifySpeed = ((1 / (longestVertex / actualVertex)) * Vector3.Distance(TransformToMove.position, extremumVector)) / speedDivisorDescend;
                }
            }
            return modifySpeed;
        }
        #endregion

        /// <summary>
        /// Move towards the next point of the curve
        /// </summary>
        void MoveTowardsNextPoint()
        {
            actualVertex = Vector3.Distance(previousPoint, nextPoint);

            dynamicSpeed = CalculateDynamicSpeed(extremumVector);

            dynamicAcceptanceRange = acceptanceRange * (longestVertex / actualVertex);
            if (Vector3.Distance(transformToMove.position, nextPoint) < dynamicAcceptanceRange)
            {
                count++;
                if (count < pointsToParse.Count)
                {
                    previousPoint = nextPoint;
                    nextPoint = pointsToParse[count];
                    nextPointDestination.Invoke(nextPoint);
                }
                else
                {
                    moveObject = false;
                    lastPointReached.Invoke();
                    return;
                }
            }
            if (count + 1 < pointsToParse.Count)
            {
                CheckCollisionBetweenPoints(count + 1);
            }
            RotateTowardsNextPoint(nextPoint);
            transformToMove.position = Vector3.MoveTowards(transformToMove.position, nextPoint, dynamicSpeed);
        }

        void MoveTowardsTeleportationPoint()
        {
            actualVertex = Vector3.Distance(previousPoint, nextPoint);
            dynamicAcceptanceRange = acceptanceRange * (longestVertex / actualVertex);
            RotateTowardsNextPoint(hittedPoint);
            transformToMove.position = Vector3.MoveTowards(transformToMove.position, hittedPoint, dynamicSpeed);
            if (Vector3.Distance(transformToMove.position, hittedPoint) < dynamicAcceptanceRange)
            {
                doesRaycastHitObject = false;
                moveObject = false;
                reachedTeleportationPoint.Invoke(hittedPoint);
            }
        }

        /// <summary>
        /// Rotate towards the next point direction of the curve
        /// </summary>
        void RotateTowardsNextPoint(Vector3 direction)
        {
            var pointDirection = direction - transform.position;
            var newDirection = Vector3.RotateTowards(transformToMove.position, pointDirection, 100f * (longestVertex / actualVertex) * Time.fixedDeltaTime, 0.5f);
            transformToMove.rotation = Quaternion.LookRotation(newDirection);
        }

        /// <summary>
        /// Check collision between the given point and the next one
        /// </summary>
        /// <param name="i">Targeted point</param>
        void CheckCollisionBetweenPoints(int i)
        {
            var targetPoint = pointsToParse[i];
            var previousTargetPoint = pointsToParse[i - 1];
            var direction = targetPoint - previousTargetPoint;
            var distance = Vector3.Distance(previousTargetPoint, targetPoint);
            Debug.DrawRay(previousTargetPoint, direction, Color.yellow);

            if (Physics.Raycast(previousPoint, direction, out raycastHit, distance))
            {
                doesRaycastHitObject = true;
                hittedPoint = raycastHit.point;
            }
        }
    }
}