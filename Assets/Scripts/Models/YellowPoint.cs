using System;
using Controllers;
using Models.Interfaces;
using Pooling.Interfaces;
using UnityEngine;

namespace Models
{
    public class YellowPoint : MonoBehaviour, IPoint, IPoolAble
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