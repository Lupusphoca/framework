namespace PierreARNAUDET.Core.ScriptableObjects.Injectors
{
    using UnityEngine;

    using PierreARNAUDET.Core.Injectors;
    using PierreARNAUDET.Core.ScriptableObjects.Models;
    using PierreARNAUDET.Core.Events;
    using PierreARNAUDET.Core.Attributes;

    public class Vector3ScriptableObjectInjector : UInjector<Vector3ScriptableObject>
    {
        [Data]
        [SerializeField] Vector3ScriptableObject vector3ToInject;
        public override Vector3ScriptableObject ObjToInject { get => vector3ToInject; set => vector3ToInject = value; }

        [Events]
        [SerializeField] Vector3Event vector3Event;

        protected override void InjectObject(Vector3ScriptableObject obj)
        {
            vector3Event?.Invoke(obj.Value);
        }
    }
}