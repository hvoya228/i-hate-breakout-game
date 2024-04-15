using Models;
using Pooling.Pools;
using UnityEngine;
using Zenject;

namespace Animation
{
    public class PointDeathEffectPlayer : MonoBehaviour
    {
        [SerializeField] private Color greenPointColor;
        [SerializeField] private Color redPointColor;
        [SerializeField] private Color yellowPointColor;
        
        private PointDeathEffectPool _pointDeathEffectPool;
        
        [Inject]
        public void Construct(PointDeathEffectPool pointDeathEffectPool)
        {
            _pointDeathEffectPool = pointDeathEffectPool;
        }

        private void OnEnable()
        {
            GreenPoint.OnKilled += PlayGreen;
            RedPoint.OnKilled += PlayRed;
            YellowPoint.OnKilled += PlayYellow;
        }
        
        private void OnDisable()
        {
            GreenPoint.OnKilled -= PlayGreen;
            RedPoint.OnKilled -= PlayRed;
            YellowPoint.OnKilled -= PlayYellow;
        }

        private void PlayGreen(Vector2 position)
        {
            Play(position, greenPointColor);
        }

        private void PlayRed(Vector2 position)
        {
            Play(position, redPointColor);
        }

        private void PlayYellow(Vector2 position)
        {
            Play(position, yellowPointColor);
        }
        
        private void Play(Vector2 position, Color color)
        {
            var pointDeathEffect = _pointDeathEffectPool.GetObject();
            pointDeathEffect.Play(position, color);
        }
    }
}