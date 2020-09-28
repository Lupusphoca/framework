namespace PierreARNAUDET.Core.Injectors
{
    using UnityEngine;

    using PierreARNAUDET.Core.Events;

    public class Collider2DInjector : UInjector<Collider2D>
    {
        [Header("Data")]
        [SerializeField] Collider2D collider2DToInject;
        public override Collider2D ObjToInject { get => collider2DToInject; set => collider2DToInject = value; }

        [Header("Events")]
        [SerializeField] Collider2DEvent collider2DEvent;
        [SerializeField] Rigidbody2DEvent attachedRigidbodyEvent;
        [SerializeField] FloatEvent bouncinessEvent;
        [SerializeField] BoundsEvent boundsEvent;
        [SerializeField] CompositeCollider2DEvent compositeEvent;
        [SerializeField] FloatEvent densityEvent;
        [SerializeField] FloatEvent frictionEvent;
        [SerializeField] BoolEvent isTriggerEvent;
        [SerializeField] Vector2Event offsetEvent;
        [SerializeField] IntEvent shapeCountEvent;
        [SerializeField] PhysicsMaterial2DEvent sharedMaterialEvent;
        [SerializeField] BoolEvent usedByCompositeEvent;
        [SerializeField] BoolEvent usedByEffectorEvent;


        protected override void InjectObject(Collider2D obj)
        {
            collider2DEvent.Invoke(obj);
            attachedRigidbodyEvent.Invoke(obj.attachedRigidbody);
            bouncinessEvent.Invoke(obj.bounciness);
            boundsEvent.Invoke(obj.bounds);
            compositeEvent.Invoke(obj.composite);
            densityEvent.Invoke(obj.density);
            frictionEvent.Invoke(obj.friction);
            isTriggerEvent.Invoke(obj.isTrigger);
            offsetEvent.Invoke(obj.offset);
            shapeCountEvent.Invoke(obj.shapeCount);
            sharedMaterialEvent.Invoke(obj.sharedMaterial);
            usedByCompositeEvent.Invoke(obj.usedByComposite);
            usedByEffectorEvent.Invoke(obj.usedByEffector);
        }
    }
}
