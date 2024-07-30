using System;
using System.Collections;
using GameInstall.Interfaces;
using UnityEngine.SceneManagement;
using AsyncOperation = UnityEngine.AsyncOperation;

namespace GameInstall
{
    public class SceneLoader
    {
        private ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string sceneName, Action OnLoaded = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, OnLoaded));
        }

        IEnumerator LoadScene(string sceneName, Action OnLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                OnLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(sceneName);

            while (!waitNextScene.isDone)
            {
                yield return null;
            }
            
            OnLoaded?.Invoke();
        }
    }
}