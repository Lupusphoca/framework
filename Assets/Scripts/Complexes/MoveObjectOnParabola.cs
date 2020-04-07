namespace Core.Complexes //!SIGNATURE : Pierre ARNAUDET
{
    using Core.Events;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

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

        [Header("Required data")]
        [SerializeField] Transform transformToMove;
        //[SerializeField] float moveSpeed;
        [SerializeField, Range(0.01f, 1f)] float acceptanceRange;
        
        [Header ("Dynamic data")]
        [SerializeField] List<Vector3> pointsToParse;

        [Header("Flow")]
        [SerializeField] Vector3Event nextPointDestination;
        [SerializeField] UnityEvent lastPointReached;

        public List<Vector3> PointsToParse { get => pointsToParse; set => pointsToParse = value; }
        public Transform TransformToMove { get => transformToMove; set => transformToMove = value; }

        public void ParseObjectAlongParabola()
        {
            moveObject = true;
            count = 0;
            previousPoint = Vector3.zero;
            longestVertex = Vector3.Distance(pointsToParse[0], pointsToParse[1]);
            nextPoint = pointsToParse[0];
        }

        public void FixedUpdate()
        {
            if (moveObject) { MoveTowardsNextPoint(); }
        }

        /// <summary>
        /// Move towards the next point of the curve
        /// </summary>
        void MoveTowardsNextPoint()
        {
            actualVertex = Vector3.Distance(previousPoint, nextPoint);
            //dynamicSpeed = (moveSpeed * Time.fixedDeltaTime / (longestVertex / actualVertex));
            dynamicSpeed = (1 / (longestVertex / actualVertex));
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
            RotateTowardsNextPoint();
            transformToMove.position = Vector3.MoveTowards(transformToMove.position, nextPoint, dynamicSpeed);
        } 

        /// <summary>
        /// Rotate towards the next point direction of the curve
        /// </summary>
        void RotateTowardsNextPoint()
        {
            var pointDirection = nextPoint - transform.position;
            var newDirection = Vector3.RotateTowards(transformToMove.position, pointDirection, 100f * (longestVertex/actualVertex) * Time.fixedDeltaTime, 0.5f);
            Debug.DrawRay(transformToMove.position, newDirection * 10f, Color.red);
            transformToMove.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}