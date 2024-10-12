using Features.PixelRender;
using Zenject;

namespace Features.BootstrapModule.GameBootstrap.GlobalInstallers {
    public class DataInstaller : Installer<DataInstaller> {
        public override void InstallBindings() {
            Container.Bind<GameCameraDataModel>()
                     .AsSingle();
        }
    }
}