using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private CanvasGroup _canvasGroup;

    protected CanvasGroup CanvasGroup => _canvasGroup;

    protected Button Button => _button;

    // private void OnEnable()
    // {
    //     _button.onClick.AddListener(OnButtonClick);
    // }
    //
    // private void OnDisable()
    // {
    //     _button.onClick.RemoveListener(OnButtonClick);
    // }

    public abstract void Open();

    public abstract void Close();

    // protected virtual void OnButtonClick();
}
