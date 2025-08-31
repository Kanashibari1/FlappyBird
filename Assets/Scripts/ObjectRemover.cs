using System;
using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    public event Action<PipePrefab> Removed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out PipePrefab pipe))
        {
            Removed?.Invoke(pipe);
        }
    }
}
