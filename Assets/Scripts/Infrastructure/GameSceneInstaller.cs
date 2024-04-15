using Animation;
using Controllers;
using Pooling.Pools;
using Spawners;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject scoreCounterPrefab;
        [SerializeField] private PointsSpawner pointsSpawner;
        [SerializeField] private LevelFinisher levelFinisher;
        [SerializeField] private PointDeathEffectPlayer pointDeathEffectPlayer;
        
        [SerializeField] private PointDeathEffectPool pointDeathEffectPool;
        
        public override void InstallBindings()
        {
            Container
                .Bind<ScoreCounter>()
                .FromComponentInNewPrefab(scoreCounterPrefab)
                .AsSingle();
            
            Container
                .Bind<PointsSpawner>()
                .FromInstance(pointsSpawner)
                .AsSingle();
            
            InstallPools();

            Container
                .Bind<LevelFinisher>()
                .FromInstance(levelFinisher)
                .AsSingle();

            Container
                .Bind<PointDeathEffectPlayer>()
                .FromInstance(pointDeathEffectPlayer)
                .AsSingle();
        }

        private void InstallPools()
        {
            Container
                .Bind<PointDeathEffectPool>()
                .FromInstance(pointDeathEffectPool)
                .AsSingle();
        }
    }
}