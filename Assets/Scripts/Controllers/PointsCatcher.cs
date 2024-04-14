using Pooling.Interfaces;
using UnityEngine;

namespace Controllers
{
    public class PointsCatcher : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            other.gameObject.GetComponent<IPoolAble>()?.Reset();
        }
    }
}