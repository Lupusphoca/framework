﻿namespace Core.Dictionaries
{
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class UDictionnary<T, U> : MonoBehaviour, IDictionary<T, U>
    {
        public abstract Dictionary<T, U> Dictionary { get; }

        public void Set(T key, U value)
        {
            if (Dictionary.ContainsKey(key))
            {
                Dictionary[key] = value;
            }
            else
            {
                Dictionary.Add(key, value);
            }
        }

        public abstract T GetKey(U value);

        public abstract U GetValue(T key);
    }
}