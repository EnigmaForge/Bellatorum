using UnityEngine;

namespace Features.PixelationRender.Test {
    public class CharacterMover : MonoBehaviour {
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");
        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterController _controller;
        [SerializeField] private float _speed = 6f;

        private void Update() {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 move = Vector3.right * moveX + Vector3.forward * moveZ;
            _controller.Move(move * (_speed * Time.deltaTime));

            bool isRunning = move != Vector3.zero;
            _animator.SetBool(IsRunning, move != Vector3.zero);
            if(isRunning)
                transform.forward = move.normalized;
        }
    }
}
