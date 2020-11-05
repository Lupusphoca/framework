namespace PierreARNAUDET.Core.ScriptableObjects.Models
{
    using System.Collections.Generic;

    using UnityEngine;

    [CreateAssetMenu(fileName = "ListGameObject", menuName = "Core/ScriptableObjects/ListGameObject")]
    public class ListGameObjectScriptableObject : UScriptableObject<List<GameObject>>
    {
        public void Add(GameObject gameObject)
        {
            this.Value.Add(gameObject);
        }
    
        public void Clear()
        {
            this.Value.Clear();
        }
    }
}