using TMPro;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private StartScreen _startScreen;
        [SerializeField] private EndScreen _endScreen; 
        [SerializeField] private TextMeshProUGUI  _scoreText;
        [SerializeField] private TextMeshProUGUI  _endText;
        
        override public void InstallBindings()
        {
            Container.BindInterfacesTo<StartScreen>().FromInstance(_startScreen).AsSingle();
            Container.BindInterfacesTo<EndScreen>().FromInstance(_endScreen).AsSingle();
            Container.Bind<ScoreCounter>().AsSingle();
            Container.BindInterfacesTo<ScoreView>().AsSingle().WithArguments(_scoreText, _endText);
        }
    }
}