namespace PierreARNAUDET.Core.Helpers
{
    using UnityEngine;

    /// <summary>
    /// Keep the main camera in memory instead of use Camera.main. This operation is less costly.
    /// </summary>
    public static class MainCamera
    {
        private static Camera mainCamera = null;

        public static Camera Get()
        {
            if (!mainCamera || !mainCamera.CompareTag("MainCamera"))
            {
                mainCamera = Camera.main;
            }

            return mainCamera;
        }
    }
}

