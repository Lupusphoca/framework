namespace PierreARNAUDET.Core.Invokers
{
    using System.Collections.Generic;

    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;
    using PierreARNAUDET.Core.Events;

    public class ListGameObjectInvoker : UInvoker<List<GameObject>>
    {
        [Data]
        [SerializeField] List<GameObject> gameObjects;
        public override List<GameObject> Obj { get => gameObjects; set => gameObjects = value; }

        [Events]
        [SerializeField] GameObjectListEvent invokedGameObject;
        protected override UnityEvent<List<GameObject>> InvokedObj => invokedGameObject;
    }
}