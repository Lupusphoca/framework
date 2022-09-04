namespace PierreARNAUDET.Modules.DOT.Transforms
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class JumpTransformDOT : UTransformDOT
    {
        [Data]
        [SerializeField] Transform _transform;
        public override Transform Transform { get => _transform; set => _transform = value; }

        [Settings]
        [SerializeField] Vector3 endValue;
        public Vector3 EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float jumpPower;
        public float JumpPower { get => jumpPower; set => jumpPower = value; }
        [SerializeField] int numJumps;
        public int NumJumps { get => numJumps; set => numJumps = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] bool snapping;
        public bool Snapping { get => snapping; set => snapping = value; }

        [Events]
        [SerializeField] UnityEvent _event;
        public override UnityEvent Event { get => _event; set => _event = value; }

        public void DOJump(Vector3 newEndValue, float newJumpPower, int newNumJumps, float newDuration, bool newSnapping)
        {
            endValue = newEndValue;
            jumpPower = newJumpPower;
            numJumps = newNumJumps;
            duration = newDuration;
            snapping = newSnapping;
            DOJump();
        }

        public void DOJump()
        {
            _transform.DOJump(endValue, jumpPower, numJumps, duration, snapping);
            _event.Invoke();
        }
    }
}