namespace PierreARNAUDET.Core.ScriptableObjects.Injectors
{
    using UnityEngine;

    using PierreARNAUDET.Core.Injectors;
    using PierreARNAUDET.Core.ScriptableObjects.Models;
    using PierreARNAUDET.Core.Events;

    public class GameObjectScriptableObjectInjector : UInjector<GameObjectScriptableObject>
    {
        [Header("Data")]
        [SerializeField] GameObjectScriptableObject gameObjectToInject;
        public override GameObjectScriptableObject ObjToInject { get => gameObjectToInject; set => gameObjectToInject = value; }

        [Header("Events")]
        [SerializeField] GameObjectEvent gameObjectEvent;

        protected override void InjectObject(GameObjectScriptableObject obj)
        {
            gameObjectEvent?.Invoke(obj.Value);
        }
    }
}