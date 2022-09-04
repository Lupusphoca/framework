namespace PierreARNAUDET.Core.Operations
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Events;

    public class Vector3MultiplicationOperation : UOperation<Vector3>
    {
        [Header("Data")]
        [SerializeField] Vector3 leftOperand;
        public override Vector3 LeftOperand { get => leftOperand; set => leftOperand = value; }
        [SerializeField] Vector3 rightOperand;
        public override Vector3 RightOperand { get => rightOperand; set => rightOperand = value; }

        [Header("Events")]
        [SerializeField] Vector3Event result;
        protected override UnityEvent<Vector3> Result => result;

        protected override Vector3 OperateObjects(Vector3 leftOperand, Vector3 rightOperand)
        {
            var x = leftOperand.x * rightOperand.x;
            var y = leftOperand.y * rightOperand.y;
            var z = leftOperand.z * rightOperand.z;
            return new Vector3(x, y, z);
        }
    }
}