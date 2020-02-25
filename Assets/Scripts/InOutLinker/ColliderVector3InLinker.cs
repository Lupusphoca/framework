namespace Core.InOutLinker
{
    using UnityEngine;

    public class ColliderVector3InLinker : UInLinker<Vector3, Collider, Vector3OutLinker>
    {
        Vector3OutLinker vector3OutLinker;

        [Header("Dynamic data")]
        [SerializeField] Vector3 data;

        public override UOutLinker<Vector3> OutLinker { get => vector3OutLinker; set => vector3OutLinker = value as Vector3OutLinker; }
        public override Vector3 Data { get => data; set => data = value; }

        public override GameObject GetGameObjectOfComponent(Collider component)
        {
            return component.gameObject;
        }
    }
}
