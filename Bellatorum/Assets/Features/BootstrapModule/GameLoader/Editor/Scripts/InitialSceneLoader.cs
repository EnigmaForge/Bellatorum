using Features.CodeGeneration.Scripts.GeneratedFiles;
using Features.SceneLoader;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Features.BootstrapModule.GameLoader.Editor {
    [InitializeOnLoad]
    public class InitialSceneLoader {
        static InitialSceneLoader() =>
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;

        private static void OnPlayModeStateChanged(PlayModeStateChange state) {
            if (AvailableToLoad(state) is false)
                return;

            if (InitialSceneAlreadyLoaded())
                return;

            ISceneLoader sceneLoader = new AsyncSceneLoader();
            sceneLoader.Load(SceneNames.InitialScene);
        }

        private static bool AvailableToLoad(PlayModeStateChange state) =>
            state == PlayModeStateChange.EnteredPlayMode && LoadGameEditorSettings.Instance.StartFromInitialScene;

        private static bool InitialSceneAlreadyLoaded() =>
            SceneManager.GetActiveScene().name == SceneNames.InitialScene;
    }
}
