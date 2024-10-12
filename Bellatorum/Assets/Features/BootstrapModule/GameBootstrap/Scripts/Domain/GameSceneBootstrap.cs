using Features.BootstrapModule.GameBootstrap.Core;
using UnityEngine;
using Zenject;

namespace Features.BootstrapModule.GameBootstrap.Domain {
    public class GameSceneBootstrap : MonoSceneBootstrap {
        [SerializeField] private SceneContext _sceneContext;
        [SerializeField] private GameObject _gameCamera;
        
        public override void Bootstrap() {
            InitializeSceneContext();
            SpawnCamera();
        }

        private void InitializeSceneContext() =>
            _sceneContext.Run();

        private void SpawnCamera() =>
            _sceneContext.Container.InstantiatePrefab(_gameCamera);
    }
}