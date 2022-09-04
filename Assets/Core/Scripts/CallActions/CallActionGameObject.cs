namespace PierreARNAUDET.Core.CallActions
{
    using UnityEngine;

    using PierreARNAUDET.Core.Attributes;

    public class CallActionGameObject : MonoBehaviour
    {
        [Data]
        [SerializeField] GameObject _gameObject;
        public GameObject GameObject { get => _gameObject; set => _gameObject = value; }

        #region Destroy
        public void DestroyObject()
        {
            if (_gameObject != null) Destroy(_gameObject);
        }

        public void DestroyObject(GameObject newGameObject)
        {
            Destroy(newGameObject);
        }
        #endregion
    }
}