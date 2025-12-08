using System;
using System.Collections.Generic;

public class EventSystem<T>
{
    private readonly List<Action<T>> _listeners = new List<Action<T>>();

    public void AddListener(Action<T> listener)
    {
        if (!_listeners.Contains(listener))
            _listeners.Add(listener);
    }

    public void RemoveListener(Action<T> listener)
    {
        if (_listeners.Contains(listener))
            _listeners.Remove(listener);
    }

    public void Clear()
    {
        _listeners.Clear();
    }

    public void Invoke(T arg)
    {
        var copy = new List<Action<T>>(_listeners);
        foreach (var listener in copy)
            listener?.Invoke(arg);
    }
}
