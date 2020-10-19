namespace PierreARNAUDET.Modules.StandaloneFileBrowser
{
    using System.Collections;

    using UnityEngine;

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
            var loader = new WWW(url);
            yield return loader;
            texture2DEvent.Invoke(loader.texture);
        }
    }
}