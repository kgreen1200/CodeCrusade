using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Placeholder class for different StateMachines in case there is a need for overlap
public class StateMachine : MonoBehaviour
{
    public State currentState;

    // Retrieves T State if it exists otherwise new T State is created
    public virtual T GetState<T>() where T : State
    {
        T target = GetComponent<T>();
        if (target == null)
        {
            target = gameObject.AddComponent<T>();
        }
        return target;
    }

    // Calls exit of previous State then calls Enter for the new one
    public virtual void Transition<T>() where T : State
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = GetState<T>();

        if (currentState != null)
        {
            currentState.Enter();
        }
    }
}
