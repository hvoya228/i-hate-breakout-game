using UnityEngine;

namespace Controllers.MoveControllers
{
    public class PlatformMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidBody;
        
        private readonly float _speed = 100.0f;
        private float _velocity;
        private readonly float _smoothTime = 0.25f;

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var moveVertical = Input.GetAxisRaw("Vertical");
            var position = rigidBody.position;
            var targetPosition = new Vector3(0, position.y + moveVertical * _speed * Time.fixedDeltaTime, 0);
            var newPosition = Mathf.SmoothDamp(position.y, targetPosition.y, ref _velocity, _smoothTime);
            rigidBody.MovePosition(new Vector2(rigidBody.position.x, newPosition));
        }
    }
}
