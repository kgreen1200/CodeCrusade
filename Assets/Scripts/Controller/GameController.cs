using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used for transitioning to different states allowing for inputs to do different things
public class GameController : StateMachine
{

    // Start is called before the first frame update
    void Start()
    {
        Transition<OverworldState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
