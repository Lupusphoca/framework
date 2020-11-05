namespace PierreARNAUDET.Core.Splitters
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;
    using PierreARNAUDET.Core.Events;

    public class GameObjectSplitter : USplitter<GameObject>
    {
        [Events]
        [SerializeField] GameObjectEvent gameObjectEvent;
        protected override UnityEvent<GameObject> Object => gameObjectEvent;
    }
}