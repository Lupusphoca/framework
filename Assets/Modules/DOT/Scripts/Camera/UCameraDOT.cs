﻿namespace PierreARNAUDET.Modules.DOT
{
    using UnityEngine;
    using UnityEngine.Events;

    public abstract class UCameraDOT : MonoBehaviour
    {
        public abstract Camera Camera { get; set; }

        public abstract UnityEvent @Event { get; set; }
    }
}