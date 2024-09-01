using Zenject;

namespace Features.SceneLoader.Installers {
    public class SceneLoaderInstaller : Installer<SceneLoaderInstaller> {
        public override void InstallBindings() {
            Container.Bind<IAsyncSceneLoader>()
                     .To<AsyncSceneLoader>()
                     .AsSingle();
        }
    }
}