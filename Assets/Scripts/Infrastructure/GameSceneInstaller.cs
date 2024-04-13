using Controllers;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject scoreCounterPrefab;
        
        public override void InstallBindings()
        {
            Container
                .Bind<ScoreCounter>()
                .FromComponentInNewPrefab(scoreCounterPrefab)
                .AsSingle();
        }
    }
}