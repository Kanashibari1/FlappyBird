using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class Factory : MonoBehaviour
{
    [SerializeField] private PipePrefab _prefab;
    
    private Transform _container;
    private PoolObject<PipePrefab> _pool;
    private List<PipePrefab> _allPipes = new();

    private void Awake()
    {
        _container = GetComponent<Transform>();  
        _pool = new PoolObject<PipePrefab>();
    }

    private void CreatePipe()
    {
        PipePrefab pipe = Instantiate(_prefab);
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
