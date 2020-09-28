namespace PierreARNAUDET.Core.Constants
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "String", menuName = "Core/Constants/String")]
    public class StringConstant : ScriptableObject{

        public string String
        {
            get => this.name;
        }
    }
}