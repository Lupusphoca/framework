namespace PierreARNAUDET.Modules.StandaloneFileBrowser
{
    using System.Collections;

    using UnityEngine;
    using UnityEngine.Networking;

    using SFB;

    using PierreARNAUDET.Core.Attributes;
    using PierreARNAUDET.Core.Events;

    public class OpenFileImage : MonoBehaviour
    {
        [Events]
        [SerializeField] Texture2DEvent texture2DEvent;

        [SerializeField]
        ExtensionFilter[] extensionFilters =
        {
            new ExtensionFilter("PNG ", "png"),
            new ExtensionFilter("JPEG ", "jpeg")
        };

        /*#if UNITY_WEBGL && !UNITY_EDITOR
        //WebGL
        [DllImport("__Internal")]
        private static extern void UploadFile(string gameObjectName, string methodName, string filter, bool multiple);

        public void OnPointerDown(PointerEventData eventData) {
            UploadFile(gameObject.name, "OnFileUpload", ".png, .jpg", false);
        }

        //Called from browser
        public void OnFileUpload(string url) {
            StartCoroutine(OutputRoutine(url));
        }
        #else*/

        public void OpenFilePanel()
        {
            var paths = StandaloneFileBrowser.OpenFilePanel("", "", extensionFilters, false);
            if (paths.Length > 0)
            {
                StartCoroutine(OutputRoutine(new System.Uri(paths[0]).AbsoluteUri));
            }
        }
        //#endif

        private IEnumerator OutputRoutine(string url)
        {
            using (UnityWebRequest loader = UnityWebRequestTexture.GetTexture(url))
            {
                yield return loader.SendWebRequest();

                if (loader.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(loader.error);
                }
                else
                {
                    var texture = DownloadHandlerTexture.GetContent(loader); // Get downloaded asset bundle
                    texture2DEvent.Invoke(texture);
                }
            }
        }
    }
}