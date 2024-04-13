using Pooling.Interfaces;
using UnityEngine;

namespace Controllers
{
    public class PointsCatcher : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var poolAble = other.gameObject.GetComponent<IPoolAble>();

            if (poolAble is not null)
            {
                poolAble.Reset();
            }
        }
    }
}