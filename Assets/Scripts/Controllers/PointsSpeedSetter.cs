﻿using Constants;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public class PointsSpeedSetter : MonoBehaviour
    {
        private ScoreCounter _scoreCounter;
        
        public float Speed { get; private set; }
        
        [Inject]
        private void Construct(ScoreCounter scoreCounter)
        {
            _scoreCounter = scoreCounter;
        }

        private void Start()
        {
            Speed = PointsSpeed.StartSpeed;
        }

        private void OnEnable()
        {
            _scoreCounter.OnProgressChanged += IncreasePointsSpeed;
        }
        
        private void OnDisable()
        {
            _scoreCounter.OnProgressChanged -= IncreasePointsSpeed;
        }

        private void IncreasePointsSpeed()
        {
            Speed += 0.2f;
        }
    }
}