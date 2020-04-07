namespace Core.ScriptableObjects.Models
{
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "ListVector3", menuName = "ScriptableObjects/ListVector3")]
    public class ListVector3ScriptableObject : UScriptableObject<List<Vector3>> { }
}