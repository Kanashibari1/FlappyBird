using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [SerializeField] private Transform _position;
    [SerializeField] private PipePrefab _pipePrefab;

    private Queue<PipePrefab> _pool = new();

    private void Create()
    {
        PipePrefab pipe = Instantiate(_pipePrefab);
        pipe.gameObject.SetActive(false);
        _pool.Enqueue(pipe);
    }

    public PipePrefab Get()
    {
        if (_pool.Count == 0)
        {
            Create();
        }

        PipePrefab pipe = _pool.Dequeue();
        pipe.transform.parent = _position;

        return pipe;
    }

    public void Put(PipePrefab pipe)
    {
        pipe.gameObject.SetActive(false);
        _pool.Enqueue(pipe);
    }

    public void Restart(List<PipePrefab> allPipes)
    {
        foreach (PipePrefab pipe in allPipes)
        {
            if (pipe.gameObject.activeSelf)
            {
                Put(pipe);
            }
        }
    }
}
