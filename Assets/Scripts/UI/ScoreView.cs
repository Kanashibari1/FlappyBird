using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _counter;
    [SerializeField] private TextMeshProUGUI _endScore;

    private TextMeshProUGUI _score;

    private void Awake()
    {
        _score = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _counter.OnValueChange += ChangeText;
    }

    private void OnDisable()
    {
        _counter.OnValueChange -= ChangeText;
    }

    private void ChangeText()
    {
        _score.text = _counter.CurrentScore.ToString();
    }

    public void EndScore()
    {
        _endScore.text = $"Ваш результат : {_counter.CurrentScore}";
    }
}
