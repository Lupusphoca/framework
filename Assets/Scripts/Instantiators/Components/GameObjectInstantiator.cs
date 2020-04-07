namespace Core.Instantiators
{
    using UnityEngine;

    using Core.ConditionalHide;
    using Core.Events;

    public class GameObjectInstantiator : MonoBehaviour
    {
        GameObject instantiateGameObject;

        [Header("Dynamic data")]
        [SerializeField] GameObject gameObject;
        [SerializeField] bool useRoot;
        [SerializeField, ConditionalHide("useRoot", false, false)] Transform root;
        [SerializeField, ConditionalHide("useRoot", false, false)] bool useParent;
        [SerializeField, ConditionalHide("useRoot", false, true)] Vector3 instantiatePoint;

        [Header("Flow")]
        [SerializeField] GameObjectEvent gameObjectEvent;

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
                instantiateGameObject = Instantiate(gameObject, root);
                if (!useParent)
                {
                    instantiateGameObject.transform.parent = null;
                }
                instantiateGameObject.transform.localScale = Vector3.one;
            }
            else
            {
                instantiateGameObject = Instantiate(gameObject, instantiatePoint, Quaternion.identity);
            }
            gameObjectEvent.Invoke(instantiateGameObject);
        }
    }
}
