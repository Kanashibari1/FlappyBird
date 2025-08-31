using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    KeyCode _jump = KeyCode.Space;

    public event Action Jumped;

    private void Update()
    {
        if (Input.GetKeyDown(_jump))
        {
            Jumped?.Invoke();
        }
    }
}
