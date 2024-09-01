using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Features.PixelationRender {
    public class PixelationRenderPass : ScriptableRenderPass {
        private readonly PixelationSettings _settings;
        private readonly Material _material;
        private readonly int _pixelBufferID = Shader.PropertyToID("_PixelBuffer");
        private readonly int _blockCountID = Shader.PropertyToID("_BlockCount");
        private readonly int _blockSizeID = Shader.PropertyToID("_BlockSize");
        private readonly int _halfBlockSizeID = Shader.PropertyToID("_HalfBlockSize");
        
        private RenderTargetIdentifier _colorBuffer;
        private RenderTargetIdentifier _pixelBuffer;

        public PixelationRenderPass(PixelationRenderSettings renderSettings, PixelationSettings settings) {
            _settings = settings;
            
            renderPassEvent = renderSettings.RenderPassEvent;
            _material = CoreUtils.CreateEngineMaterial("Hidden/PixelationRender");
        }
        
        public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData) {
            _colorBuffer = renderingData.cameraData.renderer.cameraColorTargetHandle;
            RenderTextureDescriptor descriptor = renderingData.cameraData.cameraTargetDescriptor;

            int pixelScreenHeight = _settings.ScreenHeight;
            int pixelScreenWidth = (int)(pixelScreenHeight * renderingData.cameraData.camera.aspect + 0.5f);

            _material.SetVector(_blockCountID, new Vector2(pixelScreenWidth, pixelScreenHeight));
            _material.SetVector(_blockSizeID, new Vector2(1.0f / pixelScreenWidth, 1.0f / pixelScreenHeight));
            _material.SetVector(_halfBlockSizeID, new Vector2(0.5f / pixelScreenWidth, 0.5f / pixelScreenHeight));

            descriptor.height = pixelScreenHeight;
            descriptor.width = pixelScreenWidth;

            cmd.GetTemporaryRT(_pixelBufferID, descriptor, FilterMode.Point);
            _pixelBuffer = new RenderTargetIdentifier(_pixelBufferID);
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData) {
            CommandBuffer cmd = CommandBufferPool.Get();
            using (new ProfilingScope(cmd, new ProfilingSampler("Pixelation Render Pass"))) {
                #pragma warning disable CS0618
                Blit(cmd, _colorBuffer, _pixelBuffer, _material);
                Blit(cmd, _pixelBuffer, _colorBuffer);
                #pragma warning restore CS0618
            }

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }

        public override void OnCameraCleanup(CommandBuffer cmd) {
            if (cmd == null) 
                throw new ArgumentNullException(nameof(cmd));
            
            cmd.ReleaseTemporaryRT(_pixelBufferID);
        }
    }
}