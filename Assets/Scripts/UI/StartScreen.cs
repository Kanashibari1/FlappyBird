using Main;
using UnityEngine;
using Zenject;

public class StartScreen : Window, IInitializable, IGameStartListener 
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
        Open();
        Button.onClick.AddListener(_game.StartGame);
        Time.timeScale = 0f;
    }

    public void OnStartGame()
    {
        Close();
        Button.onClick.RemoveListener(_game.StartGame);
        Time.timeScale = 1f;
    }
}
