using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper
{
    private Quaternion _maxRotation;
    
    private int _force = 5;
    private int _speed = 3;

    public Jumper(Quaternion rotation)
    {
        _maxRotation = rotation;
    }

    public void Jump(Rigidbody2D rigidbody, Transform birdTransform)
    {
        rigidbody.velocity = new Vector2(_speed, _force);
        birdTransform.transform.rotation = _maxRotation;
    }
}
