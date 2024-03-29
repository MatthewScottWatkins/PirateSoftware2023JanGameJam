using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Optional<T>
{
    [SerializeField] private bool enabled;
    [SerializeField] private T val;

    public bool Enabled { get { return enabled; } set { enabled = value; } }
    public T Value { get { return val; }set { val = value; } }

    public Optional(T initialValue)
    {
        val = initialValue;
        enabled = true;
    }
}
