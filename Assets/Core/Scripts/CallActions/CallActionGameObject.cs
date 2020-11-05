namespace PierreARNAUDET.Core.CallActions
{
    using UnityEngine;

    using PierreARNAUDET.Core.Attributes;

    public class CallActionGameObject : MonoBehaviour
    {
        [Data]
        [SerializeField] GameObject gameObject;
        public GameObject GameObject { get => gameObject; set => gameObject = value; }

        #region Destroy
        public void DestroyObject()
        {
            if (gameObject != null) Destroy(gameObject);
        }

        public void DestroyObject(GameObject newGameObject)
        {
            Destroy(newGameObject);
        }
        #endregion
    }
}