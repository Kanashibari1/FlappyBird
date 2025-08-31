using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private PipeSpawner _pipeSpawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private Bird _bird;
    [SerializeField] private ScoreView _scoreView;

    private void Start()
    {
        _startScreen.Open();
        _endScreen.Close();
        Time.timeScale = 0f;
    }

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += PlayButton;
        _endScreen.RestartButtonClicked += RestartGame;
        _bird.Dead += GameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= PlayButton;
        _endScreen.RestartButtonClicked -= RestartGame;
        _bird.Dead -= GameOver;
    }

    private void PlayButton()
    {
        _startScreen.Close();
        PlayGame();
    }

    private void PlayGame()
    {
        Time.timeScale = 1.0f;
        _bird.Restart();
        _pipeSpawner.Restart();
    }

    private void GameOver()
    {
        _endScreen.Open();
        _scoreView.EndScore();
        Time.timeScale = 0f;
    }

    private void RestartGame()
    {
        _endScreen.Close();
        PlayGame();
    }
}
