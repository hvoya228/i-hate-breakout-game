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
        public static event Action<Vector2> OnPickedWithPosition; 
        
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
            OnPickedWithPosition?.Invoke(transform.position);
            OnPicked?.Invoke();
            Reset();
        }
        
        public void Reset()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}