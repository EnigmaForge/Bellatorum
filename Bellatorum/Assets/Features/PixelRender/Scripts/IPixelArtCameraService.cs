using UnityEngine;

namespace Features.PixelRender {
    public interface IPixelArtCameraService {
        public Vector3 SnapPositionToPixelGrid(Transform renderCameraTransform, Vector3 worldPosition, float pixelWorldSize);
        public Vector3 AdjustSubPixelOffset(Camera camera, Vector3 position);
        public Vector3 GetOutputScale(float aspectRatio, float cameraZoom);
        public float GetSubPixelOutputSize(float pixelHeight, float cameraZoom);
    }
}