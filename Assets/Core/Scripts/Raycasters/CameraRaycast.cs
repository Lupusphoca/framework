namespace PierreARNAUDET.Core.Raycasters
{
    using UnityEngine;

    using PierreARNAUDET.Core.Events;

    public class CameraRaycast : URaycaster
    {
        RaycastHit raycastHit;
        public override RaycastHit RaycastHit { get => raycastHit; set => raycastHit = value; }

        [Header("Data")]
        [SerializeField] Camera camera;
        public Camera Camera { get => camera; set => camera = value; }

        [Header("Events")]
        [SerializeField] RaycastHitEvent raycastHitEvent;
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