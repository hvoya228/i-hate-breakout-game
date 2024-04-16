using UnityEngine;

namespace Controllers
{
    public class Timer : MonoBehaviour
    {
        private float _startTime;
        private bool _isRunning;

        public float CurrentTime { get; private set; }

        private void Update()
        {
            if (_isRunning)
            {
                CurrentTime += Time.deltaTime;
            }
        }
        
        public void StartTimer()
        {
            CurrentTime = 0;
            _isRunning = true;
        }

        public void StopTimer()
        {
            _isRunning = false;
        }
    }
}