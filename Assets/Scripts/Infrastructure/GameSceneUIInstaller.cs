using UnityEngine;
using UserInterfaceControllers.TextControllers;
using Zenject;

namespace Infrastructure
{
    public class GameSceneUIInstaller : MonoInstaller
    {
        [SerializeField] private ScoreText scoreText;
        
        public override void InstallBindings()
        {
            Container
                .Bind<ScoreText>()
                .FromInstance(scoreText)
                .AsSingle();
        }
    }
}