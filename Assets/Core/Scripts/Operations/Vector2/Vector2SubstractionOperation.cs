namespace PierreARNAUDET.Core.Operations
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Events;

    public class Vector2SubstractionOperation : UOperation<Vector2>
    {
        [Header("Data")]
        [SerializeField] Vector2 leftOperand;
        public override Vector2 LeftOperand { get => leftOperand; set => leftOperand = value; }
        [SerializeField] Vector2 rightOperand;
        public override Vector2 RightOperand { get => rightOperand; set => rightOperand = value; }

        [Header("Events")]
        [SerializeField] Vector2Event result;
        protected override UnityEvent<Vector2> Result => result;

        protected override Vector2 OperateObjects(Vector2 leftOperand, Vector2 rightOperand)
        {
            return leftOperand - rightOperand;
        }
    }
}