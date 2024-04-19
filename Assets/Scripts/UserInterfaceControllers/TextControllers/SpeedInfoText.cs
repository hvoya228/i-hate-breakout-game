using System;
using Controllers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterfaceControllers.TextControllers
{
    public class SpeedInfoText : MonoBehaviour
    {
        [SerializeField] private Text speedInfoText;
        
        private PointsSpeedSetter _pointsSpeedSetter;
        private PointsSpawnSpeedSetter _pointsSpawnSpeedSetter;
        private ScoreCounter _scoreCounter;
        
        [Inject]
        private void Construct(
            PointsSpeedSetter pointsSpeedSetter, 
            PointsSpawnSpeedSetter pointsSpawnSpeedSetter, 
            ScoreCounter scoreCounter)
        {
            _pointsSpeedSetter = pointsSpeedSetter;
            _pointsSpawnSpeedSetter = pointsSpawnSpeedSetter;
            _scoreCounter = scoreCounter;
        }

        private void Update()
        {
            SetText();
        }

        private void SetText()
        {
            speedInfoText.text =
                $"point maximum speed is {(float)Math.Round(_pointsSpeedSetter.Speed, 1)}" + "\n" +
                $"point spawns every {(float)Math.Round(_pointsSpawnSpeedSetter.SpawnSpeed, 1)} seconds" + "\n" +
                $"progression level {_scoreCounter.ProgressionLevel - 1} / 10 (will rise at {_scoreCounter.ScoreToTheNextProgression} scores)";
        }
    }
}