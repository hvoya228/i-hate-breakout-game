using System;
using Controllers;
using Models.Interfaces;
using Pooling.Interfaces;
using Pooling.Pools;
using UnityEngine;
using Zenject;

namespace Models
{
    public class GreenPoint : MonoBehaviour, IPoint, IPoolAble
    {
        public GameObject GameObject => gameObject;
        
        public event Action<IPoolAble> OnDestroyed;
        public static event Action OnPicked;
        public static event Action<Vector2> OnKilled; 
        
        private void OnEnable()
        {
            LevelFinisher.OnGameOver += Reset;
        }
        
        private void OnDisable()
        {
            LevelFinisher.OnGameOver -= Reset;
        }

        public void Pick()
        {
            OnPicked?.Invoke();
            Reset();
        }

        public void Reset()
        {
            OnKilled?.Invoke(transform.position);
            OnDestroyed?.Invoke(this);
        }
    }
}