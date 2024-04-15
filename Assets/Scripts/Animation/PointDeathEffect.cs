using System;
using System.Collections;
using Pooling.Interfaces;
using UnityEngine;


namespace Animation
{
    public class PointDeathEffect : MonoBehaviour, IPoolAble
    {
        [SerializeField] private ParticleSystem pointDeathEffect;
        
        public GameObject GameObject => gameObject;
        public event Action<IPoolAble> OnDestroyed;
        
        public void Play(Vector2 position, Color color)
        {
            var main = pointDeathEffect.main;
            main.startColor = color;
            transform.position = position;
            pointDeathEffect.Play();
            
            StartCoroutine(WaitForAnimationToEnd());
        }
        
        private IEnumerator WaitForAnimationToEnd()
        {
            while (pointDeathEffect.isPlaying)
            {
                yield return null;
            }
            
            OnAnimationEnded();
        }

        private void OnAnimationEnded()
        {
            Reset();
        }
        
        public void Reset()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}