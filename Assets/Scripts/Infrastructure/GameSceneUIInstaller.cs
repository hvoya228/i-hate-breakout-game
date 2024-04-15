using UnityEngine;
using UserInterfaceControllers.TextControllers;
using Zenject;

namespace Infrastructure
{
    public class GameSceneUIInstaller : MonoInstaller
    {
        [SerializeField] private ScoreText scoreText;
        [SerializeField] private PressKeyToContinueText pressKeyToContinueText;
        
        public override void InstallBindings()
        {
            Container
                .Bind<ScoreText>()
                .FromInstance(scoreText)
                .AsSingle();

            Container
                .Bind<PressKeyToContinueText>()
                .FromInstance(pressKeyToContinueText)
                .AsSingle();
        }
    }
}