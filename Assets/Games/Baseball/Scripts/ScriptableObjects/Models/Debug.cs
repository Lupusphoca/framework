namespace PierreARNAUDET.Baseball.ScriptableObjects.Models
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "Debug", menuName = "Baseball/ScriptableObjects/Debug")]
    public class Debug : ScriptableObject
    {
        [SerializeField] float distance;
        public float Distance { get => distance; set => distance = value; }

        [SerializeField] float velocity;
        public float Velocity { get => velocity; set => velocity = value; }

        [SerializeField] Vector2 worldPosition;
        public Vector2 WorldPosition { get => worldPosition; set => worldPosition = value; }
    }
}
