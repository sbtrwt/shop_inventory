using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController
{
    private Action baseEvent;

    public void AddListener(Action listener) => baseEvent += listener;

    public void RemoveListener(Action listener) => baseEvent -= listener;

    public void InvokeEvent() => baseEvent?.Invoke();

}

public class EventController<T>
{
    private Action<T> baseEvent;

    public void AddListener(Action<T> listener) => baseEvent += listener;

    public void RemoveListener(Action<T> listener) => baseEvent -= listener;

    public void InvokeEvent(T type) => baseEvent?.Invoke(type);

}
