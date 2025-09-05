using System.Collections.Generic;
using Zenject;

namespace Main
{
    public class Game
    {
        private ScoreCounter _scoreCounter;
        private PipeSpawner _pipeSpawner;
        private Bird _bird;
        
        public GameState State { get; private set; }
        
        private List<IGameListeners> _gameListeners = new();

        [Inject]
        public void Construct(ScoreCounter scoreCounter, PipeSpawner pipeSpawner, Bird bird)
        {
            _scoreCounter = scoreCounter;
            _pipeSpawner = pipeSpawner;
            _bird = bird;
        }
        
        public void AddGameListener(IGameListeners gameListener)
        {
            _gameListeners.Add(gameListener);
        }

        public void RemoveGameListener(IGameListeners gameListener)
        {
            _gameListeners.Remove(gameListener);    
        }

        public void StartGame()
        {
            foreach (IGameListeners listener in _gameListeners)
            {
                if (listener is IGameStartListener playListener)
                {
                    playListener.OnStartGame();
                }
            }
            
            State = GameState.Playing;
            _scoreCounter.Restart();
            _pipeSpawner.Restart();
            _bird.Restart();
            _bird.Dead += EndGame;
        }

        public void EndGame()
        {
            foreach (IGameListeners listener in _gameListeners)
            {
                if (listener is IGameStopListener stopListener)
                {
                    stopListener.OnStopGame();
                }
            }
            
            _bird.Dead -= EndGame;
            State = GameState.Finished;
        }
    }
}