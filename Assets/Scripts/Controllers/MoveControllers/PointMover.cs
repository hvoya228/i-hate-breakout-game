using UnityEngine;

namespace Controllers.MoveControllers
{
    public class PointMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidBody;
        private readonly float _speed = 3.0f;

        private void FixedUpdate()
        {
            MoveRight();
        }

        private void MoveRight()
        {
            var position = rigidBody.position;
            var newPosition = new Vector2(position.x + _speed * Time.fixedDeltaTime, position.y);
            rigidBody.MovePosition(newPosition);
        }
    }
}