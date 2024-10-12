using UnityEngine;
using Zenject;

namespace Features.PixelRender {
    public class CameraMover : MonoBehaviour {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private Transform _renderCameraTransform;
        [SerializeField] private Vector3 _offset = new(-5, 5, -5);
        private GameCameraDataModel _gameCameraDataModel;

        [Inject]
        public void InjectDependencies(GameCameraDataModel gameCameraDataModel) =>
            _gameCameraDataModel = gameCameraDataModel;

        private void LateUpdate() {
            if (_playerTransform == null)
                return;

            _renderCameraTransform.position = SnapPositionToGrid(_playerTransform.position);
            Vector2 targetViewPosition = _gameCameraDataModel.RenderCamera.WorldToViewportPoint(_playerTransform.position);
            Vector2 localPosition = (targetViewPosition - new Vector2(0.5f, 0.5f)) * _gameCameraDataModel.TransformData.Scale;
            _gameCameraDataModel.OutputCamera.transform.localPosition = new Vector3(localPosition.x, localPosition.y, -1f);
        }
        
        private Vector3 SnapPositionToGrid(Vector3 worldPosition) {
            Vector3 targetPosition = worldPosition + _offset;
            Vector3 localPosition = _renderCameraTransform.InverseTransformPoint(targetPosition);
            Vector3 snappedLocalPosition = SnapToPixelGrid(localPosition);
            Vector3 snappedWorldPosition = _renderCameraTransform.TransformPoint(snappedLocalPosition);

            return snappedWorldPosition;
        }
        
        private Vector3 SnapToPixelGrid(Vector3 position) {
            int pixelsPerUnit = _gameCameraDataModel.PixelPerUnit;
            float x = Mathf.Round(position.x * pixelsPerUnit) / pixelsPerUnit;
            float y = Mathf.Round(position.y * pixelsPerUnit) / pixelsPerUnit;
            float z = Mathf.Round(position.z * pixelsPerUnit) / pixelsPerUnit;
            return new Vector3(x, y, z);
        }
    }
}