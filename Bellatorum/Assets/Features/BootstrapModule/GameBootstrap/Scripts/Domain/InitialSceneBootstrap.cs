using Features.BootstrapModule.GameBootstrap.Core;
using Features.CodeGeneration.Scripts.GeneratedFiles;
using Features.SceneLoader;
using Zenject;

namespace Features.BootstrapModule.GameBootstrap.Domain {
    public class InitialSceneBootstrap : MonoSceneBootstrap {
        public override void Bootstrap() {
            InitializeProjectContext();
            LoadGameScene();
        }

        private void InitializeProjectContext() =>
            ProjectContext.Instance.EnsureIsInitialized();

        private void LoadGameScene() {
            IAsyncSceneLoader sceneLoader = ProjectContext.Instance.Container.Resolve<IAsyncSceneLoader>();
            sceneLoader.Load(SceneNames.GameScene);
        }
    }
}