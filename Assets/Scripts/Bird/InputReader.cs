using System;
using Main;
using UnityEngine;

public class InputReader : IGameTickables
{
    private KeyCode _jump = KeyCode.Space;

    public event Action Jumped;

    public void Tick()
    {
        if (Input.GetKeyDown(_jump))
        {
            Jumped?.Invoke();
        }
    }
}
