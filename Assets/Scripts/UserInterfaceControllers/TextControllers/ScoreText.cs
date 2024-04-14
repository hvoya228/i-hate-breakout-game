using Controllers;
using Models;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterfaceControllers.TextControllers
{
    public class ScoreText : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        private ScoreCounter _scoreCounter;

        [Inject]
        private void Construct(ScoreCounter scoreCounter)
        {
            _scoreCounter = scoreCounter;
        }

        private void Update()
        {
            SetScoreToText();
        }

        private void SetScoreToText()
        {
            scoreText.text = _scoreCounter.Score.ToString();
        }
    }
}