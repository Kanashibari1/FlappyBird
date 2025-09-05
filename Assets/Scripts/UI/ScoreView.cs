using Main;
using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreView : IGameStartListener, IGameStopListener
{
    private TextMeshProUGUI _endScore;
    private ScoreCounter _counter;
    private TextMeshProUGUI _score;
    private Game _game;

    [Inject]
    private void Construct(ScoreCounter counter,  TextMeshProUGUI score, TextMeshProUGUI endScore,  Game game)
    {
        _counter = counter;
        _score = score;
        _endScore = endScore;
        _game = game;
    }

    private void ChangeText()
    {
        _score.text = _counter.CurrentScore.ToString();
    }

    public void EndScore()
    {
        _endScore.text = $"your score : {_counter.CurrentScore}";
    }

    public void OnStartGame()
    {
        _counter.OnValueChange += ChangeText;
    }

    public void OnStopGame()
    {
        _counter.OnValueChange -= ChangeText;
        EndScore();
    }
}
