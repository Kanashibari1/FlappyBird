using System;

public class ScoreCounter
{
    public event Action OnValueChange;

    public int CurrentScore {  get; private set; }

    public void AddValue()
    {
        CurrentScore++;

        OnValueChange?.Invoke();
    }

    public void Restart()
    {
        CurrentScore = 0;
        OnValueChange?.Invoke();
    }
}
