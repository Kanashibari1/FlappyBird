using System.Collections.Generic;
using Zenject;

namespace Main
{
    public class GameKernal : MonoKernel, IGameStartListener, IGameStopListener
    {
        [InjectLocal]
        private List<IGameTickables>  _gameTickables = new();

        [InjectLocal]
        private List<IGameListeners> _listeners;
        
        [Inject]
        private Game _game;

        public override void Start()
        {
            base.Start();
            _game.AddGameListener(this);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            _game.RemoveGameListener(this);
        }
        
        public override void Update()
        {
            base.Update();

            if (_game.State == GameState.Playing)
            {
                foreach (IGameTickables tickables in _gameTickables)
                {
                    tickables.Tick();
                }
            }
        }
        
        public void OnStartGame()
        {
            foreach (IGameListeners listener in _listeners)
            {
                if (listener is IGameStartListener playListener)
                {
                    playListener.OnStartGame();
                }
            }
        }

        public void OnStopGame()
        {
            foreach (IGameListeners listener in _listeners)
            {
                if (listener is IGameStopListener stopListener)
                {
                    stopListener.OnStopGame();
                }
            }
        }
    }
}