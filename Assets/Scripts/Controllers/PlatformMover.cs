using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers
{
    public class PlatformMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidBody;
        private readonly float _speed = 100.0f;
        private float _velocity;
        private readonly float _smoothTime = 0.25f;

        private void FixedUpdate()
        {
            float moveVertical = Input.GetAxisRaw("Vertical");

            Vector3 targetPosition = new Vector3(0, rigidBody.position.y + moveVertical * _speed * Time.fixedDeltaTime, 0);

            float newPosition = Mathf.SmoothDamp(rigidBody.position.y, targetPosition.y, ref _velocity, _smoothTime);

            rigidBody.MovePosition(new Vector2(rigidBody.position.x, newPosition));
        }
    }
}
