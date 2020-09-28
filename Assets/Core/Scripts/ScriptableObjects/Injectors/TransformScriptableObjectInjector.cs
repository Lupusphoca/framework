namespace PierreARNAUDET.Core.ScriptableObjects.Injectors
{
    using UnityEngine;

    using PierreARNAUDET.Core.Injectors;
    using PierreARNAUDET.Core.ScriptableObjects.Models;
    using PierreARNAUDET.Core.Events;

    public class TransformScriptableObjectInjector : UInjector<TransformScriptableObject>
    {
        [Header("Data")]
        [SerializeField] TransformScriptableObject transformToInject;
        public override TransformScriptableObject ObjToInject { get => transformToInject; set => transformToInject = value; }

        [Header("Events")]
        [SerializeField] TransformEvent transformEvent;

        protected override void InjectObject(TransformScriptableObject obj)
        {
            transformEvent?.Invoke(obj.Value);
        }
    }
}