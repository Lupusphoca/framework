namespace PierreARNAUDET.Core.ScriptableObjects.Injectors
{
    using UnityEngine;

    using PierreARNAUDET.Core.Attributes;
    using PierreARNAUDET.Core.Events;
    using PierreARNAUDET.Core.Injectors;
    using PierreARNAUDET.Core.ScriptableObjects.Models;

    public class ListGameObjectScriptableObjectInjector : UInjector<ListGameObjectScriptableObject>
    {
        [Data]
        [SerializeField] ListGameObjectScriptableObject listGameObjectToInject;
        public override ListGameObjectScriptableObject ObjToInject { get => listGameObjectToInject; set => listGameObjectToInject = value; }

        [Events]
        [SerializeField] ListGameObjectScriptableObjectEvent listGameObjectScriptableObjectEvent;
        [SerializeField] GameObjectListEvent gameObjectListEvent;

        protected override void InjectObject(ListGameObjectScriptableObject obj)
        {
            listGameObjectScriptableObjectEvent.Invoke(obj);
            gameObjectListEvent.Invoke(obj.Value);
        }
    }
}