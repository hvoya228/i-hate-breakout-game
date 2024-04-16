using UnityEngine;
using Zenject;

namespace Controllers
{
    public class LevelStarter : MonoBehaviour
    {
        private Timer _timer;
        
        [Inject]
        private void Construct(Timer timer)
        {
            _timer = timer;
        }
        
        private void Start()
        {
            _timer.StartTimer();
        }
    }
}