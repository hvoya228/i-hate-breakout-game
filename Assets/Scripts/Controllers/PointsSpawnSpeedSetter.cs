using Constants;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public class PointsSpawnSpeedSetter : MonoBehaviour
    {
        private ScoreCounter _scoreCounter;
        
        public float SpawnSpeed { get; private set; }
        
        [Inject]
        private void Construct(ScoreCounter scoreCounter)
        {
            _scoreCounter = scoreCounter;
        }
        
        private void Start()
        {
            SpawnSpeed = PointsSpawnSpeed.StartSpawnSpeed;
        }
        
        private void OnEnable()
        {
            _scoreCounter.OnProgressChanged += IncreasePointsSpawnSpeed;
        }
        
        private void OnDisable()
        {
            _scoreCounter.OnProgressChanged -= IncreasePointsSpawnSpeed;
        }
        
        private void IncreasePointsSpawnSpeed()
        {
            SpawnSpeed -= 0.2f;
        }
    }
}