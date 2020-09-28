namespace PierreARNAUDET.Core.ScriptableObjects.Injectors
{
    using UnityEngine;

    using PierreARNAUDET.Core.Injectors;
    using PierreARNAUDET.Core.ScriptableObjects.Models;
    using PierreARNAUDET.Core.Events;

    public class IntScriptableObjectInjector : UInjector<IntScriptableObject>
    {
        [Header("Data")]
        [SerializeField] IntScriptableObject intToInject;
        public override IntScriptableObject ObjToInject { get => intToInject; set => intToInject = value; }

        [Header("Events")]
        [SerializeField] IntEvent intEvent;

        protected override void InjectObject(IntScriptableObject obj)
        {
            intEvent?.Invoke(obj.Value);
        }
    }
}