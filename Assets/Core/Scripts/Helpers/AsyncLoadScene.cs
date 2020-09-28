namespace PierreARNAUDET.Core.Helpers
{
    using System.Collections;

    using UnityEngine;
    using UnityEngine.SceneManagement;

    using PierreARNAUDET.Core.Constants;

    public class AsyncLoadScene : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] StringConstant scene;

        public void LoadAsynchrousScene()
        {
            LoadAsynchrousScene(scene.String);
        }

        public void LoadAsynchrousScene(StringConstant newSceneName)
        {
            LoadAsynchrousScene(newSceneName.String);
        }

        public void LoadAsynchrousScene(string newSceneName)
        {
            StartCoroutine(AsynchrousCoroutine(newSceneName));
        }

        IEnumerator AsynchrousCoroutine(string sceneToLoad)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);

            while (!asyncOperation.isDone)
            {
                yield return null;
            }
        }
    }
}