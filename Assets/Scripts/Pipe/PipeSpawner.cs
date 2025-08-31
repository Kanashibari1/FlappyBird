using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private PoolObject _poolObject;
    [SerializeField] private ObjectRemover _remover;

    private WaitForSeconds _sleep = new(2);
    private Coroutine _coroutine;
    private List<PipePrefab> _allPipes = new();

    private int _upBound = 2;
    private int _downBound = -2;

    private void OnEnable()
    {
        _remover.Removed += PutPipe;
    }

    private void OnDisable()
    {
        _remover.Removed -= PutPipe;
    }

    public void StartCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(GeneratorPipe());
    }

    private void Spawn()
    {
        PipePrefab pipe = _poolObject.Get();
        _allPipes.Add(pipe);
        int bound = Random.Range(_upBound, _downBound);
        Vector3 spawnPoint = new(transform.position.x, bound, transform.position.z);
        pipe.transform.position = spawnPoint;
        pipe.gameObject.SetActive(true);
    }

    private IEnumerator GeneratorPipe()
    {
        while (enabled)
        {
            yield return _sleep;

            Spawn();
        }
    }

    public void PutPipe(PipePrefab pipe)
    {
        _poolObject.Put(pipe);
    }

    public void Restart()
    {
        _poolObject.Restart(_allPipes);
        _allPipes.Clear();
        StartCoroutine();
    }
}
