using UnityEngine;

namespace Features.PixelRender.Example {
    public class CameraAdjuster : MonoBehaviour {
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private Camera _renderCamera;
        [SerializeField] private Camera _outputCamera;
        private IPixelArtCameraService _pixelArtCameraService;

        private void Awake() =>
            _pixelArtCameraService = new PixelArtCameraService();

        private void LateUpdate() {
            _renderCamera.transform.position = _pixelArtCameraService.SnapPositionToPixelGrid(_cameraTransform, _cameraTransform.position, GetPixelWorldSize());
            _outputCamera.transform.localPosition = _pixelArtCameraService.AdjustSubPixelOffset(_renderCamera, _cameraTransform.position);
        }

        private float GetPixelWorldSize() =>
            2f * _renderCamera.orthographicSize / _renderCamera.pixelHeight;
    }
}