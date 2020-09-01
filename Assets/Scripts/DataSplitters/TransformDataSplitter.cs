namespace Core.DataSplitters
{
    using Core.Events;
    using UnityEngine;
    using UnityEngine.Events;

    public class TransformDataSplitter : UDataSplitter<Transform>
    {
        [Header("Out flow")]
        [SerializeField] TransformEvent transformSplitted;
        [SerializeField] FloatEvent rotationEulerAngleX;
        [SerializeField] FloatEvent rotationEulerAngleY;
        [SerializeField] FloatEvent rotationEulerAngleZ;

        [SerializeField] FloatEvent worldPositionX;
        [SerializeField] FloatEvent worldPositionY;
        [SerializeField] FloatEvent worldPositionZ;

        protected override UnityEvent<Transform> ObjectSplitted => transformSplitted;

        public override void SplitData(Transform obj)
        {
            rotationEulerAngleX.Invoke(obj.eulerAngles.x);
            rotationEulerAngleY.Invoke(obj.eulerAngles.y);
            rotationEulerAngleZ.Invoke(obj.eulerAngles.z);
            worldPositionX.Invoke(obj.position.x);
            worldPositionY.Invoke(obj.position.y);
            worldPositionZ.Invoke(obj.position.z);
        }
    }
}
