namespace PierreARNAUDET.Core.CallActions
{
    using UnityEngine;

    public class CallActionRigidbody2D : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] Rigidbody2D rigidbody2D;
        public Rigidbody2D Rigidbody2D { get => rigidbody2D; set => rigidbody2D = value; }

        #region AddForce
        [Header("Data : AddForce")]
        [SerializeField] Vector2 forceVector2;
        public Vector2 ForceVector2 { get => forceVector2; set => forceVector2 = value; }
        [SerializeField] ForceMode2D forceMode2D;
        public ForceMode2D ForceMode2D { get => forceMode2D; set => forceMode2D = value; }

        /// <summary>
        /// Add a force to the rigidbody2D
        /// </summary>
        public void AddForce()
        {
            if (rigidbody2D != null)
            {
                rigidbody2D.AddForce(forceVector2, forceMode2D);
            }
        }

        /// <summary>
        /// Add a force to the rigidbody2D
        /// </summary>
        /// <param name="newVector3Array">Direction and force applied to the rigidbody2D</param>
        public void AddForce(Vector2 newforceVector2)
        {
            if (rigidbody2D != null)
            {
                rigidbody2D.AddForce(newforceVector2);
            }
        }

        /// <summary>
        /// Add a force to the rigidbody2D
        /// </summary>
        /// <param name="forceVector2">Direction and force applied to the rigidbody2D</param>
        /// <param name="forceMode2D">Specified to type of force you want to add</param>
        public void AddForce(Vector2 newforceVector2, ForceMode2D newForceMode2D)
        {
            if (rigidbody2D != null)
            {
                rigidbody2D.AddForce(newforceVector2, newForceMode2D);
            }
        }
        #endregion

        #region StopVelocity
        public void StopVelocity()
        {
            rigidbody2D.velocity = Vector2.zero;
        }
        #endregion
    }
}