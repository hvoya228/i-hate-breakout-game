using Animation;
using Loaders;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private GameObject sceneTransitionAnimationPrefab;
        
        public override void InstallBindings()
        {
            Container
                .Bind<SceneTransitionAnimation>()
                .FromComponentInNewPrefab(sceneTransitionAnimationPrefab)
                .AsSingle();
            
            Container
                .Bind<ScenesLoader>()
                .AsSingle();
        }
    }
}