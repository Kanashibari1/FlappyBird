using Main;
using UnityEngine;
using Zenject;

public class EndScreen : Window, IInitializable, IGameStopListener, IGameStartListener
{
    private Game _game;

    [Inject]
    public void Construct(Game game)
    {
        _game = game;
    }
    
    public override void Close()
    {
        Button.interactable = false;
        CanvasGroup.alpha = 0f;
        CanvasGroup.blocksRaycasts = false;
    }

    public override void Open()
    {
        Button.interactable = true;
        CanvasGroup.alpha = 1.0f;
        CanvasGroup.blocksRaycasts = true;
    }

    public void Initialize()
    {
        Close();
    }
    
    public void OnStopGame()
    {
        Open();
        Button.onClick.AddListener(_game.StartGame);
        Time.timeScale = 0f;
    }

    public void OnStartGame()
    {
        Button.onClick.RemoveListener(_game.StartGame);
        Close();
    }
}
