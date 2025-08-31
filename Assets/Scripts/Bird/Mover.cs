using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    private InputReader _inputReader;
    private Rigidbody2D _rigidbody;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;
    private Vector3 _startPosition;

    private int _force = 5;
    private float rotationSpeed = 1f;
    private int _speed = 3;

    private int _minRotationZ = -60;
    private int _maxRotationZ = 60;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputReader.Jumped += Move;
    }

    private void OnDisable()
    {
        _inputReader.Jumped -= Move;
    }

    private void Start()
    {
        _startPosition = transform.position;
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
    }

    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, rotationSpeed * Time.deltaTime);
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(_speed, _force);
        transform.rotation = _maxRotation;
    }

    public void Restart()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody.velocity = Vector2.zero;
    }
}
