namespace Core.InOutLinker
{
    using UnityEngine;

    public class ColliderTransformInLinker : UInLinker<Transform, Collider, TransformOutLinker>
    {
        TransformOutLinker transformOutLinker;

        [Header("Dynamic data")]
        [SerializeField] Transform data;
        [SerializeField] Collider component;

        public override ILinker<Transform> OutLinker { get => transformOutLinker; set => transformOutLinker = value as TransformOutLinker; }
        public override Transform Data { get => data; set => data = value; }
        public override Collider Component { get => component; set => component = value; }

        public override GameObject GetGameObjectOfComponent(Collider component)
        {
            return component.gameObject;
        }
    }
}
