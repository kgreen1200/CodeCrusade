using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used for transitioning to different states allowing for inputs to do different things
public class GameController : StateMachine
{
    public GameObject pauseMenu;

    public static GameController Instance { get; private set; }

    // Called before Start()
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
