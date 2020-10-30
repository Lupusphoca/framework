namespace PierreARNAUDET.Modules.DOT.Rigidbodies
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class LookAtRigidbodyDOT : URigidbodyDOT
    {
        [Data]
        [SerializeField] Rigidbody rigidbody;
        public override Rigidbody Rigidbody { get => rigidbody; set => rigidbody = value; }

        [Settings]
        [SerializeField] Vector3 towards;
        public Vector3 Towards { get => towards; set => towards = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] AxisConstraint axisConstraint;
        public AxisConstraint AxisConstraint { get => axisConstraint; set => axisConstraint = value; }
        [SerializeField] Vector3 up;
        public Vector3 Up { get => up; set => up = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOLookAt(Vector3 newTowards, float newDuration, AxisConstraint newAxisConstraint, Vector3 newUp)
        {
            towards = newTowards;
            duration = newDuration;
            axisConstraint = newAxisConstraint;
            up = newUp;
            DOLookAt();
        }

        public void DOLookAt()
        {
            rigidbody.DOLookAt(towards, duration, axisConstraint, up);
            @event.Invoke();
        }
    }
}