using System;
using UnityEngine;

public class HandlerCollision : MonoBehaviour
{
    public event Action<Iinteractable> OnCollisionEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Iinteractable component))
        {
            OnCollisionEnter?.Invoke(component);
        }
    }
}
