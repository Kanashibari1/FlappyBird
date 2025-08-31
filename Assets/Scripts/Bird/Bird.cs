using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(HandlerCollision))]
public class Bird : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;

    private Mover _mover;
    private HandlerCollision _handlerCollision;

    public event Action Dead;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _handlerCollision = GetComponent<HandlerCollision>();
    }

    private void OnEnable()
    {
        _handlerCollision.OnCollisionEnter += ProcessCollision;
    }

    private void OnDisable()
    {
        _handlerCollision.OnCollisionEnter -= ProcessCollision;
    }

    private void ProcessCollision(Iinteractable interactable)
    {
        if(interactable is Ground || interactable is Pipe)
        {
            Dead?.Invoke();
        }
        else if(interactable is ScoreZone)
        {
            _scoreCounter.AddValue();
        }
    }

    public void Restart()
    {
        _mover.Restart();
        _scoreCounter.Restart();
    }
}
