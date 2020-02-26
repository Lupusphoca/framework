namespace Core.InOutLinker
{
    using UnityEditor;
    using UnityEngine;

    public abstract class UInLinker<T, U, V> : MonoBehaviour
    {
        public abstract ILinker<T> OutLinker { get; set; }

        public abstract U Component { get; set; }
        public abstract T Data { get; set; }

        public abstract GameObject GetGameObjectOfComponent(U component);

        public virtual void GetOutLinker(T data)
        {
            if (Component != null)
            {
                var gameObject = GetGameObjectOfComponent(Component);
                OutLinker = gameObject.GetComponent<V>() as ILinker<T>;
                Link(data);
            } else
            {
                Debug.LogError($"Please set Component value before execute GetOutLinker function !");
            }
        }

        private void Link(T data)
        {
            Data = data;
            OutLinker.Continue(Data);
        }

        private void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox($"Component value need to be set before executing GetOutLinker function !", MessageType.Warning);
        }
    }
}