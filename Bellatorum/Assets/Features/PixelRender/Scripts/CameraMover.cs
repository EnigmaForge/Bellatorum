using UnityEngine;
using Zenject;

namespace Features.PixelRender {
    public class CameraMover : MonoBehaviour {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private Transform _renderCameraTransform;
        private GameCameraDataModel _gameCameraDataModel;

        [Inject]
        public void InjectDependencies(GameCameraDataModel gameCameraDataModel) =>
            _gameCameraDataModel = gameCameraDataModel;

        private void LateUpdate() {
            if (_targetTransform == null)
                return;

            _renderCameraTransform.position = SnapPositionToGrid(_targetTransform.position);
            Vector2 targetViewPosition = _gameCameraDataModel.RenderCamera.WorldToViewportPoint(_targetTransform.position);
            Vector2 localPosition = (targetViewPosition - new Vector2(0.5f, 0.5f)) * _gameCameraDataModel.TransformData.Scale;
            _gameCameraDataModel.OutputCamera.transform.localPosition = new Vector3(localPosition.x, localPosition.y, -1f);
        }
        
        private Vector3 SnapPositionToGrid(Vector3 worldPosition) {
            float pixelWorldSize = _gameCameraDataModel.PixelWorldSize;
            Vector3 localPosition = _renderCameraTransform.InverseTransformDirection(worldPosition);
            Vector3 localPositionInPixels = localPosition / pixelWorldSize;
            Vector3 integerMovement = Vector3Int.RoundToInt(localPositionInPixels);
            Vector3 movement = integerMovement * pixelWorldSize;
            return movement.x * _renderCameraTransform.right + movement.y * _renderCameraTransform.up + movement.z * _renderCameraTransform.forward;
        }
    }
}