namespace Core.Transformers
{
    using UnityEngine;

    public abstract class UTransformer : MonoBehaviour
    {
        public abstract void Move (Transform transform);
    }
}