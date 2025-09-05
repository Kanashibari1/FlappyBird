namespace Main
{
    public interface IGameListeners
    {
        
    }

    public interface IGameStartListener : IGameListeners
    {
        void OnStartGame();
    }

    public interface IGameStopListener : IGameListeners
    {
        void OnStopGame();
    }
}