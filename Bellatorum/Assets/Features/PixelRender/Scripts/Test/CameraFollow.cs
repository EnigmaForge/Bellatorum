using System;
using UnityEngine;

namespace Features.PixelRender.Test {
    public class CameraFollow : MonoBehaviour {
        [SerializeField] private Transform _player;
        [SerializeField] private Vector3 _offset;
        
        private void Update() {
            if (_player == null)
                return;
                
            transform.position = _player.position + _offset;
        }
    }
}
