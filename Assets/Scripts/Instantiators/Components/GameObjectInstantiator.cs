namespace Core.Instantiators
{
    using UnityEngine;

    using Core.ConditionalHide;

    public class GameObjectInstantiator : MonoBehaviour
    {
        [Header("Dynamic data")]
        [SerializeField] GameObject gameObject;
        [SerializeField] bool useRoot;
        [SerializeField, ConditionalHide("useRoot")] Transform root;
        [SerializeField, ConditionalHide("useRoot", false, true)] Vector3 instantiatePoint;

        public GameObject GameObject { get => gameObject; set => gameObject = value; }
        public Transform Root { get => root; set => root = value; }
        public Vector3 InstantiatePoint { get => instantiatePoint; set => instantiatePoint = value; }

        public void Instantiate (GameObject newGameObject)
        {
            gameObject = newGameObject;
        }

        public void Instantiate ()
        {
            if (useRoot)
            {
                Instantiate(gameObject, root);
            }
            else
            {
                Instantiate(gameObject, instantiatePoint, Quaternion.identity);
            }
        }
    }
}
