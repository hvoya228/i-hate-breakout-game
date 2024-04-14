using UnityEngine;

namespace Controllers.MoveControllers
{
    public class PointMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidBody;
        
        public float Speed {get; set;}

        private void FixedUpdate()
        {
            MoveRight();
        }

        private void MoveRight()
        {
            var position = rigidBody.position;
            var newPosition = new Vector2(position.x + Speed * Time.fixedDeltaTime, position.y);
            rigidBody.MovePosition(newPosition);
        }
    }
}