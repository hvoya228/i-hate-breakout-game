using System;
using Models.Interfaces;
using Pooling.Interfaces;
using UnityEngine;

namespace Models
{
    public class RedPoint : MonoBehaviour, IPoint, IPoolAble
    {
        public GameObject GameObject => gameObject;
        public event Action<IPoolAble> OnDestroyed;
        public static event Action OnPicked;
        
        public void Pick()
        {
            OnPicked?.Invoke();
            Reset();
        }
        
        public void Reset()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}