using System;
using System.Collections;
using Infrastructure.StateMachine.CoroutineRunner;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services.SceneLoadService
{
    public class SceneLoadService : ISceneLoadService
    {
        private readonly ICoroutineRunner _coroutineRunner;
        
        public SceneLoadService(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void LoadScene(string sceneName, Action onSceneLoad = null) => 
            _coroutineRunner.StartCoroutine(SceneLoaderRoutine(sceneName, onSceneLoad));

        IEnumerator SceneLoaderRoutine(string sceneName, Action onSceneLoad)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                onSceneLoad?.Invoke();
                yield break;
            }
            
            AsyncOperation sceneLoader = SceneManager.LoadSceneAsync(sceneName);
            while (!sceneLoader.isDone)
            {
                yield return null;
            }
            
            onSceneLoad?.Invoke();
        }

    }   
}