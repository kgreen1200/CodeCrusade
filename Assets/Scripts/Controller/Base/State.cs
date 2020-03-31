using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    protected GameController owner;

    // Called before Start()
    void Awake()
    {
        owner = GetComponent<GameController>();
    }

    public virtual void Enter()
    {
        AddListeners();
    }

    public virtual void Exit()
    {
        RemoveListeners();
    }

    // In case object is destroyed without exiting state
    protected virtual void OnDestroy()
    {
        RemoveListeners();
    }

    // Placeholder for adding listeners to InputController
    protected virtual void AddListeners()
    {

    }

    // Placeholder for removing listeners from InputController
    protected virtual void RemoveListeners()
    {

    }
}
