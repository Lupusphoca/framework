namespace PierreARNAUDET.Core.CallActions
{
    using System.Collections.Generic;
    using UnityEngine;

    using PierreARNAUDET.Core.Events;

    public class CallActionString : MonoBehaviour
    {
        #region Concat
        [Header("Data : Concat")]
        [SerializeField] List<string> concatArgs = new List<string>();

        [Header("Events")]
        [SerializeField] StringEvent stringConcatEvent;

        /// <summary>
        /// Add a new string argument to the concat list
        /// </summary>
        /// <param name="newString"></param>
        public void AddArgToConcat(string newString)
        {
            concatArgs.Add(newString);
        }

        /// <summary>
        /// Replace one string from the list with an other one
        /// </summary>
        /// <param name="i">Rank to replace</param>
        /// <param name="newString">String replaced at the specified rank</param>
        public void ReplaceArgToConcat (int i, string newString)
        {
            concatArgs[i] = newString;
        }

        /// <summary>
        /// Clear list of string to concat
        /// </summary>
        public void ClearArgsToConcat()
        {
            concatArgs.Clear();
        }

        /// <summary>
        /// Concat list already referenced
        /// </summary>
        public void Concat() {
            var stringArray = concatArgs.ToArray();
            var @string = string.Concat(stringArray);
            stringConcatEvent.Invoke(@string);
        }

        /// <summary>
        /// Concat array of string given
        /// </summary>
        /// <param name="stringArray">Array string that you want to concat</param>
        public void Concat(string[] stringArray)
        {
            var @string = string.Concat(stringArray);
            stringConcatEvent.Invoke(@string);
        }
        #endregion
    }
}