using Controllers;
using Spawners;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject scoreCounterPrefab;
        [SerializeField] private PointsSpawner pointsSpawnerPrefab;
        
        public override void InstallBindings()
        {
            Container
                .Bind<ScoreCounter>()
                .FromComponentInNewPrefab(scoreCounterPrefab)
                .AsSingle();
            
            Container
                .Bind<PointsSpawner>()
                .FromInstance(pointsSpawnerPrefab)
                .AsSingle();
        }
    }
}