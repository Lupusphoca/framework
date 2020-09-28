namespace PierreARNAUDET.Core.Physics
{
    using UnityEngine;

    using NaughtyAttributes;

    using PierreARNAUDET.Core.Events;

    [DisallowMultipleComponent]
    public class OnTriggerEnterComponent : MonoBehaviour
    {
        [InfoBox("Only work on an object that have a Collider2D", EInfoBoxType.Warning)]
        public Collider2DEvent collider2DEvent;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            collider2DEvent.Invoke(collision);
        }
    }
}