namespace PierreARNAUDET.Core.Operations
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;
    using PierreARNAUDET.Core.Events;

    public class IntSubstractionOperation : UOperation<int>
    {
        [Data]
        [SerializeField] int leftOperand;
        public override int LeftOperand { get => leftOperand; set => leftOperand = value; }
        [SerializeField] int rightOperand;
        public override int RightOperand { get => rightOperand; set => rightOperand = value; }

        [Events]
        [SerializeField] IntEvent intResult;
        protected override UnityEvent<int> Result => intResult;

        protected override int OperateObjects(int leftOperand, int rightOperand)
        {
            return leftOperand - rightOperand;
        }
    }
}