using Main;
using UnityEngine;

public class BirdTracker : IGameTickables
{
    private Bird _bird;
    private Camera _tracker;

    public BirdTracker(Bird bird,  Camera tracker)
    {
        _bird = bird;
        _tracker = tracker;
    }

    public void Tick()
    {
        Vector2 position = _tracker.transform.position;
        position.x = _bird.transform.position.x;
        _tracker.transform.position = position;
    }
}
