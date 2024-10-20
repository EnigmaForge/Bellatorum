using UnityEngine;
using Zenject;

namespace Features.CameraModule {
    public class GameCameraSetup : MonoBehaviour {
        [SerializeField] private Camera _renderCamera;
        [SerializeField] private Vector2Int _resolution;
        [SerializeField] private float _cameraZoom;
        private GameCameraDataModel _gameCameraDataModel;

        [Inject]
        public void InjectDependencies(GameCameraDataModel gameCameraDataModel) =>
            _gameCameraDataModel = gameCameraDataModel;

        private void Start() {
            SetupRenderSetting();
            SetupRenderCamera();
        }

        private void SetupRenderSetting() {
            RenderSetting renderSetting = _gameCameraDataModel.RenderSetting;
            renderSetting.Resolution = _resolution;
            renderSetting.CameraZoom = _cameraZoom;
            _gameCameraDataModel.RenderSetting = renderSetting;
        }

        private void SetupRenderCamera() {
            _renderCamera.targetTexture.height = _resolution.y;
            _renderCamera.targetTexture.width = _resolution.x;
            _renderCamera.orthographicSize = _cameraZoom;
        }
    }
}