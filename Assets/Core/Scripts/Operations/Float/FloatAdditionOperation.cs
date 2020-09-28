namespace PierreARNAUDET.Core.Operations
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Events;

    public class FloatAdditionOperation : UOperation<float>
    {
        [Header("Data")]
        [SerializeField] float leftOperand;
        public override float LeftOperand { get => leftOperand; set => leftOperand = value; }
        [SerializeField] float rightOperand;
        public override float RightOperand { get => rightOperand; set => rightOperand = value; }

        [Header("Events")]
        [SerializeField] FloatEvent result;
        protected override UnityEvent<float> Result => result;

        protected override float OperateObjects(float leftOperand, float rightOperand)
        {
            return leftOperand + rightOperand;
        }
    }
}