namespace PierreARNAUDET.Core.Operations
{
    using UnityEngine;
    using UnityEngine.Events;

    [DisallowMultipleComponent]
    public abstract class UOperation<T> : MonoBehaviour, IOperation
    {
        public abstract T LeftOperand { get; set; }
        public abstract T RightOperand { get; set; }

        protected abstract UnityEvent<T> Result { get; }

        public void Operate()
        {
            Result.Invoke(OperateObjects(LeftOperand, RightOperand));
        }

        public void OperateLeft(T leftOperand)
        {
            LeftOperand = leftOperand;
            Operate();
        }

        public void OperateRight(T rightOperand)
        {
            RightOperand = rightOperand;
            Operate();
        }

        protected abstract T OperateObjects(T leftOperand, T rightOperand);
    }
}