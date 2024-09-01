using System;
using UnityEngine;

namespace Features.PixelationRender {
    [Serializable]
    public struct PixelationSettings {
        [field: SerializeField] public int ScreenHeight { get; private set; }
    }
}