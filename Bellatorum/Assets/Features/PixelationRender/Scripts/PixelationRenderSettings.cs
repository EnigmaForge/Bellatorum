using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Features.PixelationRender {
    [Serializable]
    public struct PixelationRenderSettings {
        [field: SerializeField] public bool RenderOnScene { get; private set; }
        [field: SerializeField] public RenderPassEvent RenderPassEvent { get; private set; }
    }
}