using Models;
using UnityEngine;

namespace Controllers
{
    public class ScoreCounter : MonoBehaviour
    {
        public int Score { get; private set; }

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
            Score += 5;
        }

        private void DecreaseScore()
        {
            Score -= 10;
        }
    }
}