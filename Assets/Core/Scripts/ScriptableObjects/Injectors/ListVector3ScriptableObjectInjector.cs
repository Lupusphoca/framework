namespace PierreARNAUDET.Core.ScriptableObjects.Injectors
{
    using UnityEngine;

    using PierreARNAUDET.Core.Injectors;
    using PierreARNAUDET.Core.ScriptableObjects.Models;
    using PierreARNAUDET.Core.Events;

    public class ListVector3ScriptableObjectInjector : UInjector<ListVector3ScriptableObject>
    {
        [Header("Data")]
        [SerializeField] ListVector3ScriptableObject listVector3ToInject;
        public override ListVector3ScriptableObject ObjToInject { get => listVector3ToInject; set => listVector3ToInject = value; }

        [Header("Events")]
        [SerializeField] ListVector3ScriptableObjectEvent listVector3ScriptableObjectEvent;
        [SerializeField] Vector3ListEvent vector3ListEvent;

        protected override void InjectObject(ListVector3ScriptableObject obj)
        {
            listVector3ScriptableObjectEvent.Invoke(obj);
            vector3ListEvent.Invoke(obj.Value);
        }
    }
}