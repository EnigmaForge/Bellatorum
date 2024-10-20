using Features.PixelRender;
using UnityEngine;
using Zenject;

namespace Features.CameraModule {
    public class GameCameraAdjuster : MonoBehaviour {
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private Camera _renderCamera;
        [SerializeField] private Camera _outputCamera;
        [SerializeField] private Transform _outputTransform;
        private IPixelArtCameraService _pixelArtCameraService;
        private GameCameraDataModel _gameCameraDataModel;

        [Inject]
        private void InjectDependencies(IPixelArtCameraService pixelArtCameraService, GameCameraDataModel gameCameraDataModel) {
            _pixelArtCameraService = pixelArtCameraService;
            _gameCameraDataModel = gameCameraDataModel;
        }

        private void Start() =>
            AdjustZoom();

        private void LateUpdate() =>
            AdjustCameraPosition();

        private void AdjustZoom() {
            _outputTransform.localScale = _pixelArtCameraService.GetOutputScale(_gameCameraDataModel.AspectRatio, _gameCameraDataModel.RenderSetting.CameraZoom);
            _outputCamera.orthographicSize = _pixelArtCameraService.GetSubPixelOutputSize(_gameCameraDataModel.RenderSetting.Resolution.y, _gameCameraDataModel.RenderSetting.CameraZoom);
        }

        private void AdjustCameraPosition() {
            _renderCamera.transform.position = _pixelArtCameraService.SnapPositionToPixelGrid(_cameraTransform, _cameraTransform.position, _gameCameraDataModel.PixelWorldSize);
            _outputCamera.transform.localPosition = _pixelArtCameraService.AdjustSubPixelOffset(_renderCamera, _cameraTransform.position);
        }
    }
}