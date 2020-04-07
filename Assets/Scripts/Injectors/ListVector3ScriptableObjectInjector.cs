namespace Core.ScriptableObjects.Injectors
{
    using UnityEngine;
    using Core.Injectors;
    using Core.ScriptableObjects.Models;
    using Core.Events;

    public class ListVector3ScriptableObjectInjector : UInjector<ListVector3ScriptableObject>
    {
        [Header("Flow")]
        [SerializeField] ListVector3ScriptableObjectEvent listVector3ScriptableObjectEvent;
        [SerializeField] Vector3ListEvent vector3ListEvent;

        protected override void InjectObject(ListVector3ScriptableObject obj)
        {
            listVector3ScriptableObjectEvent.Invoke(obj);
            vector3ListEvent.Invoke(obj.Value);
        }
    }
}