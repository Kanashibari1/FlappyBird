using UnityEngine;
using Zenject;

namespace Installer
{
    public class SceneInstaller : MonoInstaller
    {
         [SerializeField] private Bird _bird;
         [SerializeField] private PipePrefab _pipePrefab;
         [SerializeField] private Transform _container;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Bird>().FromComponentInNewPrefab(_bird).AsSingle();
            Container.BindInterfacesAndSelfTo<InputReader>().AsSingle();
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<BirdTracker>().AsSingle();
            Container.Bind<Factory>().AsSingle().WithArguments(_pipePrefab, _container);
            Container.Bind<PipeSpawner>().FromComponentInHierarchy().AsSingle();
        }
    }
}