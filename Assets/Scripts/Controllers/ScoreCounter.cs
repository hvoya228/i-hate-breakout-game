using System;
using Models;
using UnityEngine;

namespace Controllers
{
    public class ScoreCounter : MonoBehaviour
    {
        private int _progressionLevel = 1;
        
        public int ProgressionLevel => _progressionLevel;
        public int ScoreToTheNextProgression { get; private set; } = 1;
        public int Score { get; private set; }

        public Action OnProgressChanged;

        private void OnEnable()
        {
            GreenPoint.OnPicked += IncreaseScore;
            YellowPoint.OnPicked += DecreaseScore;
        }

        private void OnDisable()
        {
            GreenPoint.OnPicked -= IncreaseScore;
            YellowPoint.OnPicked -= DecreaseScore;
        }

        private void IncreaseScore()
        {
            Score += 1;
            CheckProgression();
        }

        private void DecreaseScore()
        {
            Score -= 10;
        }

        private void CheckProgression()
        {
            if (_progressionLevel >= 10) return;
            if (Score != ScoreToTheNextProgression) return;
            
            OnProgressChanged?.Invoke();
            _progressionLevel++;
            ScoreToTheNextProgression = Score * 2;
        }
    }
}