namespace PierreARNAUDET.Modules.DOT.Transforms
{
    using UnityEngine;
    using UnityEngine.Events;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class BlendableLocalMoveByTransformDOT : UTransformDOT
    {
        [Data]
        [SerializeField] Transform _transform;
        public override Transform Transform { get => _transform; set => _transform = value; }

        [Settings]
        [SerializeField] Vector3 byValue;
        public Vector3 ByValue { get => byValue; set => byValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] bool snapping;
        public bool Snapping { get => snapping; set => snapping = value; }

        [Events]
        [SerializeField] UnityEvent _event;
        public override UnityEvent Event { get => _event; set => _event = value; }

        public void DOBlendableLocalMoveBy(Vector3 newByValue, float newDuration, bool newSnapping)
        {
            byValue = newByValue;
            duration = newDuration;
            snapping = newSnapping;
            DOBlendableLocalMoveBy();
        }

        public void DOBlendableLocalMoveBy()
        {
            _transform.DOBlendableLocalMoveBy(byValue, duration, snapping);
            _event.Invoke();
        }
    }
}