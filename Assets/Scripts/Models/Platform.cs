using Models.Interfaces;
using UnityEngine;

namespace Models
{
    public class Platform : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            other.gameObject.GetComponent<IPoint>()?.Pick();
        }
    }
}