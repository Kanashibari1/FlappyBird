using System.Collections.Generic;
using UnityEngine;

public class Factory
{
    private PipePrefab _prefab;
    private Transform _container;
    private PoolObject<PipePrefab> _pool;
    private List<PipePrefab> _allPipes = new();

    public Factory(PipePrefab prefab,  Transform container)
    {
        _container = container;
        _prefab = prefab;
        _pool = new PoolObject<PipePrefab>();
    }

    private void CreatePipe()
    {
        PipePrefab pipe = GameObject.Instantiate(_prefab);
        _pool.Add(pipe);
    }

    public PipePrefab GetPipe()
    {
        if (_pool.Pool.Count == 0)
        {
           CreatePipe(); 
        }
        
        PipePrefab  pipe = _pool.Get();
        _allPipes.Add(pipe);
        pipe.transform.parent = _container;
        pipe.gameObject.SetActive(true);
        
        return pipe;
    }

    public void PutPipe(PipePrefab pipe)
    {
        _pool.Put(pipe);
    }

    public void Restart()
    {
        foreach (var pipe in _allPipes)
        {
            if (pipe.gameObject.activeSelf)
            {
                pipe.gameObject.SetActive(false);
                _pool.Put(pipe);
            }
        }
        
        _allPipes.Clear();
    }
}
