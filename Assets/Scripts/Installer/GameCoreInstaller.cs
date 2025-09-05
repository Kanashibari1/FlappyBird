using Main;
using UnityEngine;
using Zenject;

namespace Installer
{
    [CreateAssetMenu(fileName = "GameCoreInstaller", menuName = "Installers/GameCoreInstaller")]
    public class GameCoreInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Game>().AsSingle();
        }
    }
}