using Models.Interfaces;
using UnityEngine;

namespace Models
{
    public class Platform : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var point = other.gameObject.GetComponent<IPoint>();

            if (point is not null)
            {
                point.Pick();
                Debug.Log("Picked");
            }
        }
    }
}