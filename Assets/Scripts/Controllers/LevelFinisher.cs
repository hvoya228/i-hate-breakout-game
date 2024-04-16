using System;
using DG.Tweening;
using Models;
using Spawners;
using UnityEngine;
using UserInterfaceControllers.TextControllers;
using Zenject;

namespace Controllers
{
    public class LevelFinisher : MonoBehaviour
    {
        private PointsSpawner _pointsSpawner;
        private Timer _timer;
        private PressKeyToContinueText _pressKeyToContinueText;
        
        public static Action OnGameOver;

        [Inject]
        private void Construct(
            PointsSpawner pointsSpawner, 
            Timer timer,
            PressKeyToContinueText pressKeyToContinueText)
        {
            _pointsSpawner = pointsSpawner;
            _timer = timer;
            _pressKeyToContinueText = pressKeyToContinueText;
        }
        
        private void Start()
        {
            _pressKeyToContinueText.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                InitializeGameOver();
            }
        }

        private void OnEnable()
        {
            RedPoint.OnPicked += InitializeGameOver;
        }
        
        private void OnDisable()
        {
            RedPoint.OnPicked -= InitializeGameOver;
        }
        
        private void InitializeGameOver()
        {
            OnGameOver?.Invoke();
            _timer.StopTimer();
            _pointsSpawner.StopSpawning();
            ActivateExitButton();
        }

        private void ActivateExitButton()
        {
            _pressKeyToContinueText.gameObject.SetActive(true);
            _pressKeyToContinueText.Text.DOFade(1f, 2f);
        }
    }
}