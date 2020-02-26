namespace Core.Raycasters
{
    using UnityEngine;

    using Core.Events;

    public abstract class URaycaster : MonoBehaviour, IRaycaster
    {
        public abstract RaycastHit RaycastHit { get; set; }
        public abstract RaycastHitEvent RaycastHitEvent { get; set; }

        public abstract void Raycast();
    }
}