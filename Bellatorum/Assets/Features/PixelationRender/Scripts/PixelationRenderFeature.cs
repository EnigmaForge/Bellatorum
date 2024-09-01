using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Features.PixelationRender {
    public class PixelationRenderFeature : ScriptableRendererFeature {
        [SerializeField] private PixelationRenderSettings _renderSettings;
        [SerializeField] private PixelationSettings _settings;
        private PixelationRenderPass _renderPass;
        
        public override void Create() =>
            _renderPass = new PixelationRenderPass(_renderSettings, _settings);

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData) {
            #if UNITY_EDITOR
            if (!_renderSettings.RenderOnScene && renderingData.cameraData.isSceneViewCamera)
                return;
            #endif
            
            renderer.EnqueuePass(_renderPass);
        }
    }
}