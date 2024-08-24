using UnityEngine;

namespace Features.BootstrapModule.GameBootstrap.Core {
    public abstract class MonoSceneBootstrap : MonoBehaviour, ISceneBootstrap {
        private void Start() =>
            Bootstrap();

        public abstract void Bootstrap();
    }
}
