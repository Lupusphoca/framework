namespace PierreARNAUDET.Core.Raycasters
{
    using UnityEngine;

    using PierreARNAUDET.Core.Events;

    public class CameraRaycast : URaycaster
    {
        private RaycastHit raycastHit;
        public override RaycastHit RaycastHit { get => raycastHit; set => raycastHit = value; }

        [Header("Data")]
        [SerializeField] Camera _camera;
        public Camera Camera { get => _camera; set => _camera = value; }

        [Header("Events")]
        [SerializeField] RaycastHitEvent raycastHitEvent;
        public override RaycastHitEvent RaycastHitEvent { get => raycastHitEvent; set => raycastHitEvent = value; }

        public override void Raycast ()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit))
            {
                RaycastHitEvent.Invoke(RaycastHit);
            }
        }
    }
}