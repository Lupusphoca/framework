namespace PierreARNAUDET.Core.Helpers
{
    using UnityEngine;

    public class DestroyComponent : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] GameObject gameObject;
        public GameObject GameObject { get => gameObject; set => gameObject = value; }

        /// <summary>
        /// Destroy the given gameobject
        /// </summary>
        /// <param name="newGameObject">GameObject to destroy</param>
        public void DestroyGameObject(GameObject newGameObject)
        {
            Destroy(newGameObject);
        }

        /// <summary>
        /// Destroy the gameobject referenced in the script object
        /// </summary>
        public void DestroyGameObject()
        {
            if (gameObject != null) {
                DestroyGameObject(gameObject);
                gameObject = null;
            }
        }
    }
}