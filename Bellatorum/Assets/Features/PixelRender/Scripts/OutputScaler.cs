using UnityEngine;
using Zenject;

namespace Features.PixelRender {
    public class OutputScaler : MonoBehaviour {
        private GameCameraDataModel _gameCameraDataModel;

        [Inject]
        public void InjectDependencies(GameCameraDataModel gameCameraDataModel) =>
            _gameCameraDataModel = gameCameraDataModel;

        private void OnEnable() =>
            _gameCameraDataModel.OnRenderSettingsChanged += ScaleOutput;

        private void OnDisable() =>
            _gameCameraDataModel.OnRenderSettingsChanged -= ScaleOutput;

        private void ScaleOutput(RenderSetting renderSetting) {
            float aspectRatio = _gameCameraDataModel.AspectRatio;
            float canvasHeight = renderSetting.CameraZoom * 2f;
            
            transform.localScale = new Vector3(canvasHeight * aspectRatio, canvasHeight, 1f);
            _gameCameraDataModel.TransformData.Scale = transform.localScale;
        }
    }
}
