namespace PierreARNAUDET.Core.ScriptableObjects.Injectors
{
    using UnityEngine;

    using PierreARNAUDET.Core.Injectors;
    using PierreARNAUDET.Core.ScriptableObjects.Models;
    using PierreARNAUDET.Core.Events;

    public class FloatScriptableObjectInjector : UInjector<FloatScriptableObject>
    {
        [Header("Data")]
        [SerializeField] FloatScriptableObject floatToInject;
        public override FloatScriptableObject ObjToInject { get => floatToInject; set => floatToInject = value; }

        [Header("Events")]
        [SerializeField] FloatEvent floatEvent;

        protected override void InjectObject(FloatScriptableObject obj)
        {
            floatEvent?.Invoke(obj.Value);
        }
    }
}