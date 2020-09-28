namespace PierreARNAUDET.Core.Injectors
{
    using UnityEngine;

    using PierreARNAUDET.Core.Events;

    public class Rigidbody2DInjector : UInjector<Rigidbody2D>
    {
        [Header("Data")]
        [SerializeField] Rigidbody2D rigidbody2DToInject;
        public override Rigidbody2D ObjToInject { get => rigidbody2DToInject; set => rigidbody2DToInject = value; }

        [Header("Events")]
        [SerializeField] Rigidbody2DEvent rigidbody2DEvent;
        [SerializeField] FloatEvent angularDragEvent;
        [SerializeField] FloatEvent angularVelocityEvent;
        [SerializeField] IntEvent attachedColliderCountEvent;
        [SerializeField] RigidbodyType2DEvent bodytypeEvent;
        [SerializeField] Vector2Event centerOfMassEvent;
        [SerializeField] CollisionDetectionMode2DEvent collisionDetectionModeEvent;
        [SerializeField] RigidbodyConstraints2DEvent constraintsEvent;
        [SerializeField] FloatEvent dragEvent;
        [SerializeField] BoolEvent freezeRotationEvent;
        [SerializeField] FloatEvent gravityScaleEvent;
        [SerializeField] FloatEvent inertiaEvent;
        [SerializeField] RigidbodyInterpolation2DEvent interpolation;
        [SerializeField] BoolEvent isKinematicEvent;
        [SerializeField] FloatEvent massEvent;
        [SerializeField] Vector2Event positionEvent;
        [SerializeField] FloatEvent rotationEvent;
        [SerializeField] PhysicsMaterial2DEvent sharedMaterial;
        [SerializeField] BoolEvent simulatedEvent;
        [SerializeField] RigidbodySleepMode2DEvent sleepModeEvent;
        [SerializeField] BoolEvent useAutoMassEvent;
        [SerializeField] BoolEvent useFullKinematicContactsEvent;
        [SerializeField] Vector2Event velocityEvent;
        [SerializeField] Vector2Event worldCenterOfMassEvent;

        protected override void InjectObject(Rigidbody2D obj)
        {
            rigidbody2DEvent.Invoke(obj);
            angularDragEvent.Invoke(obj.angularDrag);
            angularVelocityEvent.Invoke(obj.angularVelocity);
            attachedColliderCountEvent.Invoke(obj.attachedColliderCount);
            bodytypeEvent.Invoke(obj.bodyType);
            centerOfMassEvent.Invoke(obj.centerOfMass);
            collisionDetectionModeEvent.Invoke(obj.collisionDetectionMode);
            constraintsEvent.Invoke(obj.constraints);
            dragEvent.Invoke(obj.drag);
            freezeRotationEvent.Invoke(obj.freezeRotation);
            gravityScaleEvent.Invoke(obj.gravityScale);
            inertiaEvent.Invoke(obj.inertia);
            interpolation.Invoke(obj.interpolation);
            isKinematicEvent.Invoke(obj.isKinematic);
            massEvent.Invoke(obj.mass);
            positionEvent.Invoke(obj.position);
            rotationEvent.Invoke(obj.rotation);
            sharedMaterial.Invoke(obj.sharedMaterial);
            simulatedEvent.Invoke(obj.simulated);
            sleepModeEvent.Invoke(obj.sleepMode);
            useAutoMassEvent.Invoke(obj.useAutoMass);
            useFullKinematicContactsEvent.Invoke(obj.useFullKinematicContacts);
            velocityEvent.Invoke(obj.velocity);
            worldCenterOfMassEvent.Invoke(obj.worldCenterOfMass);
        }
    }
}
