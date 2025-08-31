using System;
using UnityEngine;

public class EndScreen : Window
{
    public event Action RestartButtonClicked;

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

    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}
