namespace PierreARNAUDET.Core.Helpers
{
    using UnityEngine;

    public class DestroyComponent : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] GameObject _gameObject;
        public GameObject GameObject { get => _gameObject; set => _gameObject = value; }

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
            if (_gameObject != null) {
                DestroyGameObject(_gameObject);
                _gameObject = null;
            }
        }
    }
}