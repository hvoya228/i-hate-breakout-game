using UnityEngine;
using Zenject;

namespace Controllers
{
    public class PointsSpeedSetter : MonoBehaviour
    {
        private Timer _timer;
        
        public float PointsSpeed { get; private set; }
        public float PointsSpawnSpeed { get; private set; }
        
        [Inject]
        private void Construct(Timer timer)
        {
            _timer = timer;
        }

        private void Start()
        {
            PointsSpawnSpeed = 2f;
        }

        private void IncreasePointsSpeed()
        {
            
        }

        private void IncreasePointsSpawnSpeed()
        {
            
        }
    }
}