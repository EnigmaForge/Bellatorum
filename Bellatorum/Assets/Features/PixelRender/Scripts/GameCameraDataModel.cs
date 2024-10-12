using System;
using Features.Extensions.UnityWrapper;
using UnityEngine;

namespace Features.PixelRender {
    public class GameCameraDataModel {
        private RenderSetting _renderSetting;

        public TransformData TransformData { get; set; } = new();
        public Camera RenderCamera { get; set; }
        public Camera OutputCamera { get; set; }
        
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

        public event Action<RenderSetting> OnRenderSettingsChanged;
    }
}