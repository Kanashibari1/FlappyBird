using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private Bird _bird;

    void Update()
    {
        Vector2 position = transform.position;
        position.x = _bird.transform.position.x;
        transform.position = position;
    }
}
