namespace PierreARNAUDET.Modules.DOT.RectTransforms
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class JumpAnchorPosRectTransformDOT : URectTransformDOT
    {
        [Data]
        [SerializeField] RectTransform rectTransform;
        public override RectTransform RectTransform { get => rectTransform; set => rectTransform = value; }

        [Settings]
        [SerializeField] Vector2 endValue;
        public Vector2 EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float jumpPower;
        public float JumpPower { get => jumpPower; set => jumpPower = value; }
        [SerializeField] int numJumps;
        public int NumJumps { get => numJumps; set => numJumps = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] bool snapping;
        public bool Snapping { get => snapping; set => snapping = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOJumpAnchorPos(Vector2 newEndValue, float newJumpPower, int newNumJumps, float newDuration, bool newSnapping)
        {
            endValue = newEndValue;
            jumpPower = newJumpPower;
            numJumps = newNumJumps;
            duration = newDuration;
            snapping = newSnapping;
            DOJumpAnchorPos();
        }

        public void DOJumpAnchorPos()
        {
            rectTransform.DOJumpAnchorPos(endValue, jumpPower, numJumps, duration, snapping);
            @event.Invoke();
        }
    }
}