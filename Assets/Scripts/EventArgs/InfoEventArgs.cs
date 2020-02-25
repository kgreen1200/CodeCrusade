using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EventArgs with custom types
public class InfoEventArgs<T> : EventArgs
{
    public T info;

    // Default Constructor
    public InfoEventArgs()
    {
        info = default(T);
    }

    // EventArg with info of type T
    public InfoEventArgs(T info)
    {
        this.info = info;
    }
}
