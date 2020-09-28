namespace PierreARNAUDET.Core.BoolOperators
{
    using UnityEngine;

    using Core.Events;

    public abstract class UBoolOperator : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] BoolEvent validOperator;
        [SerializeField] BoolEvent invalidOperator;

        public abstract bool FirstBool { get; set; }
        public abstract bool SecondBool { get; set; }

        public void CheckBoolOperator ()
        {
            if (Operator())
            {
                validOperator.Invoke(true);
            } else
            {
                invalidOperator.Invoke(false);
            }
        }

        protected abstract bool Operator();
    }
}
