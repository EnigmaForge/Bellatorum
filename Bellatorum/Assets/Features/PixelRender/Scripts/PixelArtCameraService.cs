using UnityEngine;

namespace Features.PixelRender {
    public class PixelArtCameraService : IPixelArtCameraService {
        public Vector3 SnapPositionToPixelGrid(Transform renderCameraTransform, Vector3 worldPosition, float pixelWorldSize) {
            Vector3 localPosition = renderCameraTransform.InverseTransformDirection(worldPosition);
            Vector3 localPositionInPixels = localPosition / pixelWorldSize;
            Vector3 integerMovement = Vector3Int.RoundToInt(localPositionInPixels);
            Vector3 movement = integerMovement * pixelWorldSize;
            return movement.x * renderCameraTransform.right + movement.y * renderCameraTransform.up + movement.z * renderCameraTransform.forward;
        }

        public Vector3 AdjustSubPixelOffset(Camera camera, Vector3 position) {
            Vector2 targetViewPosition = (Vector2)camera.WorldToViewportPoint(position) - new Vector2(0.5f, 0.5f);
            Vector2 localPosition = targetViewPosition * GetOutputScale(camera.aspect, camera.orthographicSize);
            return new Vector3(localPosition.x, localPosition.y, -1f);
        }

        public Vector3 GetOutputScale(float aspectRatio, float cameraZoom) {
            float canvasHeight = cameraZoom * 2f;
            return new Vector3(canvasHeight * aspectRatio, canvasHeight, 1f);
        }

        public float GetSubPixelOutputSize(float pixelHeight, float cameraZoom) {
            float canvasOnScreenLimit = 1f - 2f / pixelHeight;
            return canvasOnScreenLimit * cameraZoom;
        }
    }
}