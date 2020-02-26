namespace Core.Raycasters
{
    using UnityEngine;

    using Core.Events;

    public class CameraRaycast : URaycaster
    {
        RaycastHit raycastHit;

        [Header("Required data")]
        [SerializeField] Camera camera;

        [Header("Events")]
        [SerializeField] RaycastHitEvent raycastHitEvent;

        public override RaycastHit RaycastHit { get => raycastHit; set => raycastHit = value; }
        public override RaycastHitEvent RaycastHitEvent { get => raycastHitEvent; set => raycastHitEvent = value; }

        public override void Raycast ()
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit))
            {
                RaycastHitEvent.Invoke(RaycastHit);
            }
        }
    }
}