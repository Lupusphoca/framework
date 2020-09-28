namespace PierreARNAUDET.Core.Raycasters
{
    using UnityEngine;

    using PierreARNAUDET.Core.Events;

    public abstract class URaycaster : MonoBehaviour, IRaycaster
    {
        public abstract RaycastHit RaycastHit { get; set; }
        public abstract RaycastHitEvent RaycastHitEvent { get; set; }

        public abstract void Raycast();
    }
}