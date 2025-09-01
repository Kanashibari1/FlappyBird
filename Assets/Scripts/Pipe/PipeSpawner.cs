using System.Collections;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Factory _factory;
    [SerializeField] private ObjectRemover _remover;

    private WaitForSeconds _sleep = new(2);
    private Coroutine _coroutine;

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
        PipePrefab pipe = _factory.GetPipe();
        int bound = Random.Range(_upBound, _downBound);
        Vector3 spawnPoint = new(transform.position.x, bound, transform.position.z);
        pipe.transform.position = spawnPoint;
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
        _factory.PutPipe(pipe);
    }

    public void Restart()
    {
        _factory.Restart();
        StartCoroutine();
    }
}
