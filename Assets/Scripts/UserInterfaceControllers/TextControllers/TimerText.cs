using Controllers;
using UnityEngine;
using UnityEngine.UI;
using UserInterfaceControllers.Formatters;
using Zenject;

namespace UserInterfaceControllers.TextControllers
{
    public class TimerText : MonoBehaviour
    {
        [SerializeField] private Text timerText;
        
        private Timer _timer;
        
        [Inject]
        private void Construct(Timer timer)
        {
            _timer = timer;
        }

        private void Update()
        {
            SetText();
        }

        private void SetText()
        {
            timerText.text = TimeFormatter.Format(_timer.CurrentTime);
        }
    }
}