using UnityEngine;

namespace Features.PixelRender {
    public class CameraMovement : MonoBehaviour {
        [SerializeField] private Camera _targetCamera;
        [SerializeField] private Vector2Int _targetResolution;
        [SerializeField] private float _orthographicSize;
        [SerializeField] private Transform _follow;
        [SerializeField] private Vector3 _offset;
        private Transform _cameraTransform;
        private int _pixelsPerUnit;
        private Vector2 _subPixelOffset;

        private void Awake() {
            _cameraTransform = _targetCamera.transform;
            _pixelsPerUnit = (int)(_targetResolution.y / (_orthographicSize * 2f));
        }

        private void LateUpdate() {
            Vector3 targetPosition = _follow.position + _offset;
            Vector3 localPosition = _cameraTransform.InverseTransformPoint(targetPosition);
            Vector3 snappedLocalPosition = SnapToPixelGrid(localPosition);
            Vector3 snappedWorldPosition = _cameraTransform.TransformPoint(snappedLocalPosition);

            _cameraTransform.position = snappedWorldPosition;
        }
        
        private Vector3 SnapToPixelGrid(Vector3 position) {
            float x = Mathf.Round(position.x * _pixelsPerUnit) / _pixelsPerUnit;
            float y = Mathf.Round(position.y * _pixelsPerUnit) / _pixelsPerUnit;
            float z = Mathf.Round(position.z * _pixelsPerUnit) / _pixelsPerUnit;
            return new Vector3(x, y, z);
        }
    }
}