using System;
using Main;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour, IGameTickables
{
    private ScoreCounter _scoreCounter;
    private HandlerCollision _handlerCollision;
    private InputReader _inputReader;
    private Rigidbody2D _rigidbody;
    private Jumper _jumper;
    
    private Quaternion _minRotation;
    private Quaternion _maxRotation;
    private Vector3 _startPosition;
    
    private int _minRotationZ = -60;
    private int _maxRotationZ = 60;
    private float _rotationSpeed = 1f;

    public event Action Dead;

    [Inject]
    private void Construct(ScoreCounter scoreCounter, InputReader inputReader)
    {
        _scoreCounter = scoreCounter;
        _inputReader = inputReader;
    }

    public void Awake()
    {
        _handlerCollision = GetComponent<HandlerCollision>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _jumper = new Jumper(_maxRotation);
        _startPosition = transform.position;
    }

    private void OnEnable()
    {
        _handlerCollision.OnCollisionEnter += ProcessCollision;
        _inputReader.Jumped += Move;
    }
    
    private void OnDisable()
    {
        _handlerCollision.OnCollisionEnter -= ProcessCollision;
        _inputReader.Jumped -= Move;
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
    
    private void Move()
    {
        _jumper.Jump(_rigidbody, transform);
    }

    public void Tick()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }
    
    public void Restart()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody.velocity = Vector2.zero;
    }
}
