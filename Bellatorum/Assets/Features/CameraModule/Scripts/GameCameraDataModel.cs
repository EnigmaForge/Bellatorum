using System;

namespace Features.CameraModule {
    public class GameCameraDataModel {
        private RenderSetting _renderSetting;

        public RenderSetting RenderSetting {
            get =>
                _renderSetting;
            set {
                _renderSetting = value;
                OnRenderSettingsChanged?.Invoke(value);
            }
        }

        public float AspectRatio =>
            (float)RenderSetting.Resolution.x / RenderSetting.Resolution.y;
        public int PixelPerUnit =>
            (int)(RenderSetting.Resolution.y / (RenderSetting.CameraZoom * 2f));
        public float PixelWorldSize =>
            2f * RenderSetting.CameraZoom / RenderSetting.Resolution.y;

        public event Action<RenderSetting> OnRenderSettingsChanged;
    }
}