namespace PierreARNAUDET.Core.BoolOperators
{
    using UnityEngine;

    public class AndBoolOperator : UBoolOperator
    {
        [Header("Data")]
        [SerializeField] bool firstBool;
        public override bool FirstBool { get => firstBool; set => firstBool = value; }
        [SerializeField] bool secondBool;
        public override bool SecondBool { get => secondBool; set => secondBool = value; }

        protected override bool Operator()
        {
            if (firstBool && secondBool)
            {
                return true;
            }
            return false;
        }
    }
}
