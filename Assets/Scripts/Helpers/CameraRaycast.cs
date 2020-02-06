namespace Core.Helpers
{
    using UnityEngine;

    using Core.Events;

    public class CameraRaycast : MonoBehaviour
    {
        RaycastHit raycastHit;

        [Header("Required data")]
        [SerializeField] Camera camera;

        [Header("Events")]
        [SerializeField] RaycastHitEvent raycastHitEvent;

        public void Raycast ()
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit))
            {
                raycastHitEvent.Invoke(raycastHit);
            }
        }
    }
}
