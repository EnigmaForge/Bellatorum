using Features.GameCameraModule.Installers;
using Features.SceneLoader.Installers;
using UnityEngine;
using Zenject;

namespace Features.BootstrapModule.GameBootstrap.GlobalInstallers {
    [CreateAssetMenu(fileName = "SO_" + nameof(ProjectContextInstaller) + "_Default", menuName = "Configurations/Installers/GlobalInstallers/" + nameof(ProjectContextInstaller))]
    public class ProjectContextInstaller : ScriptableObjectInstaller {
        public override void InstallBindings() {
            DataInstaller.Install(Container);
            SceneLoaderInstaller.Install(Container);
            PixelRenderInstaller.Install(Container);
        }
    }
}
