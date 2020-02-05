namespace Core.BoolOperators
{
    using UnityEngine;

    public class AndBoolOperator : UBoolOperator
    {
        [Header("Dynamic Data")]
        [SerializeField] bool firstBool;
        [SerializeField] bool secondBool;

        public override bool FirstBool { get => firstBool; set => firstBool = value; }
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
