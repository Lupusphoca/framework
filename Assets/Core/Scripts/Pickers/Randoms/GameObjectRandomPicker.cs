namespace PierreARNAUDET.Core.Pickers
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;
    using PierreARNAUDET.Core.Events;

    public class GameObjectRandomPicker : URandomPicker<GameObject>
    {
        [Events]
        [SerializeField] GameObjectEvent pickedGameObject;
        protected override UnityEvent<GameObject> PickedObject => pickedGameObject;
    }
}