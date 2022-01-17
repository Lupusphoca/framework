namespace PierreARNAUDET.Core.Instantiators
{
    using UnityEngine;

    using PierreARNAUDET.Core.Attributes;
    using PierreARNAUDET.Core.Events;

    public class GameObjectInstantiator : MonoBehaviour
    {
        GameObject instantiateGameObject;

        [Header("Data")]
        [SerializeField] GameObject _gameObject;
        public GameObject GameObject { get => _gameObject; set => _gameObject = value; }
        [SerializeField] bool useRoot;
        [SerializeField, ConditionalHide("useRoot", false, false)] Transform root;
        public Transform Root { get => root; set => root = value; }
        [SerializeField, ConditionalHide("useRoot", false, false)] bool useParent;
        [SerializeField, ConditionalHide("useRoot", false, true)] Vector3 instantiatePoint;
        public Vector3 InstantiatePoint { get => instantiatePoint; set => instantiatePoint = value; }

        [Header("Events")]
        [SerializeField] GameObjectEvent gameObjectEvent;

        /// <summary>
        /// Instantiate the referenced gameobject
        /// </summary>
        public void Instantiate ()
        {
            Instantiate(_gameObject);
        }

        /// <summary>
        /// Instantiate a gameobject on the active scene
        /// </summary>
        /// <param name="newGameObject">GameObject to instantiate</param>
        public void Instantiate (GameObject newGameObject)
        {
            if (useRoot)
            {
                instantiateGameObject = Instantiate(newGameObject, root);
                if (!useParent)
                {
                    instantiateGameObject.transform.parent = null;
                }
                instantiateGameObject.transform.localScale = Vector3.one;
            }
            else
            {
                instantiateGameObject = Instantiate(newGameObject, instantiatePoint, Quaternion.identity);
            }
            gameObjectEvent.Invoke(instantiateGameObject);
        }
    }
} //TODO Make others 'Instantiate' functions that required others data like 'root', 'rotation', et cetera.