using System.Collections.Generic;

public class PoolObject<T>
{
    private Queue<T> _pool = new();

    public Queue<T> Pool => _pool;

    public void Add(T obj)
    {
        _pool.Enqueue(obj);
    }

    public T Get()
    {
        return _pool.Dequeue();
    }

    public void Put(T pipe)
    {
        _pool.Enqueue(pipe);
    }
}