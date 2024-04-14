using UnityEngine;

namespace Controllers.MoveControllers
{
    public class PlatformMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidBody;
        
        private readonly float _force = 25.0f;
        private readonly float _drag = 0.1f;

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var moveVertical = Input.GetAxisRaw("Vertical");

            if (Mathf.Abs(moveVertical) < 0.1f)
            {
                rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.zero, _drag);
            }
            else
            {
                rigidBody.AddForce(new Vector2(0, moveVertical * _force));
            }
        }
    }
}
