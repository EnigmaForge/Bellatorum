using UnityEngine;
using Zenject;

namespace Features.PixelRender {
    public class GameCameraSetup : MonoBehaviour {
        [SerializeField] private Camera _renderCamera;
        [SerializeField] private Camera _outputCamera;
        [SerializeField] private Vector2Int _resolution;
        [SerializeField] private float _cameraZoom;
        private GameCameraDataModel _gameCameraDataModel;

        [Inject]
        public void InjectDependencies(GameCameraDataModel gameCameraDataModel) =>
            _gameCameraDataModel = gameCameraDataModel;

        private void Start() =>
            SetupRenderSetting();

        private void SetupRenderSetting() {
            RenderSetting renderSetting = _gameCameraDataModel.RenderSetting;
            renderSetting.Resolution = _resolution;
            renderSetting.CameraZoom = _cameraZoom;
            _gameCameraDataModel.RenderSetting = renderSetting;
            _gameCameraDataModel.RenderCamera = _renderCamera;
            _gameCameraDataModel.OutputCamera = _outputCamera;
        }
    }
}