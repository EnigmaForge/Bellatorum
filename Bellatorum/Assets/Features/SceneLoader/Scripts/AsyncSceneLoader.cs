using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Features.SceneLoader {
    public class AsyncSceneLoader : IAsyncSceneLoader {
        private LoadSceneMode _loadSceneMode;
        private UnloadSceneOptions _unloadSceneOptions;
        private Action _onCompleteCallback;

        public IAsyncSceneLoader SetLoadMode(LoadSceneMode loadSceneMode) {
            _loadSceneMode = loadSceneMode;
            return this;
        }

        public IAsyncSceneLoader SetUnloadOptions(UnloadSceneOptions unloadSceneOptions) {
            _unloadSceneOptions = unloadSceneOptions;
            return this;
        }

        public IAsyncSceneLoader OnComplete(Action callback) {
            _onCompleteCallback = callback;
            return this;
        }

        public void Load(string sceneName) {
            AsyncOperation loadSceneOperation = SceneManager.LoadSceneAsync(sceneName, _loadSceneMode);
            InvokeOnComplete(loadSceneOperation, _onCompleteCallback);
            ResetData();
        }

        public void UnLoad(string sceneName) {
            AsyncOperation unloadSceneOperation = SceneManager.UnloadSceneAsync(sceneName, _unloadSceneOptions);
            InvokeOnComplete(unloadSceneOperation, _onCompleteCallback);
            ResetData();
        }

        private void InvokeOnComplete(AsyncOperation asyncOperation, Action callback) {
            if (asyncOperation == null)
                return;

            asyncOperation.completed += _ => callback.Invoke();
        }

        private void ResetData() {
            _loadSceneMode = default;
            _unloadSceneOptions = default;
            _onCompleteCallback = null;
        }
    }
}