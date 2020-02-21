namespace Core.Enumerations
{
    using UnityEngine;
    using System.Collections.Generic;
    using System.Linq;

    using static Core.Enumerations.MouseButtons;
    using Core.Dictionaries;

    public class MouseButtons : UDictionnary<Buttons, int>
    {
        [System.Flags] public enum Buttons {
            Left = 1, 
            Right = 1 << 1, 
            Middle = 1 << 2
        }

        Dictionary<Buttons, int> intCorresponding = new Dictionary<Buttons, int>() {
            {Buttons.Left, 0},
            {Buttons.Right, 1},
            {Buttons.Middle, 2}
        };

        public override Dictionary<Buttons, int> Dictionary => intCorresponding;

        public void Set(Buttons key, int value)
        {
            if (intCorresponding.ContainsKey(key))
            {
                intCorresponding[key] = value;
            }
            else
            {
                intCorresponding.Add(key, value);
            }
        }

        public override Buttons GetKey(int value)
        {
            var result = Buttons.Left;
            if (intCorresponding.ContainsValue(value))
            {
                result = intCorresponding.FirstOrDefault(x => x.Value == value).Key;
                return result;
            }

            Debug.LogWarning($"A data need to be added and int value {result} will be use temporary");
            return result;
        }

        public override int GetValue(Buttons key)
        {
            var result = 0;
            if (intCorresponding.ContainsKey(key))
            {
                result = intCorresponding[key];
                return result;
            }

            Debug.LogWarning($"A data need to be added and int value {result} will be use temporary");
            return result;
        }
    }
}