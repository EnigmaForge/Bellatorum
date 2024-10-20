using Features.PixelRender;
using Zenject;

namespace Features.GameCameraModule.Installers {
    public class PixelRenderInstaller : Installer<PixelRenderInstaller> {
        public override void InstallBindings() {
            Container.BindInterfacesTo<PixelArtCameraService>()
                     .AsSingle();
        }
    }
}