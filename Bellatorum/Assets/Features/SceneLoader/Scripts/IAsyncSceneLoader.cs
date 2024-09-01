using System;
using UnityEngine.SceneManagement;

namespace Features.SceneLoader {
    public interface IAsyncSceneLoader : ISceneLoader {
        public IAsyncSceneLoader SetLoadMode(LoadSceneMode loadSceneMode);
        public IAsyncSceneLoader SetUnloadOptions(UnloadSceneOptions unloadSceneOptions);
        public IAsyncSceneLoader OnComplete(Action callback);
    }
}