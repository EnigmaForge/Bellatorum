using UnityEngine;

namespace Features.PixelationRender.Test {
    public class FollowObject : MonoBehaviour {
        [SerializeField] private Transform _follow;
        [SerializeField] private Vector3 _offset;

        private void Update() =>
            transform.position = _follow.position + _offset;
    }
}