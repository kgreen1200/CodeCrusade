using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : State
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        owner.pauseMenu.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        owner.pauseMenu.SetActive(false);
    }

    protected override void OnDestroy()
    {
        if (owner.pauseMenu != null)
        {
            owner.pauseMenu.SetActive(false);
        }
    }

    protected override void AddListeners()
    {
        InputController.fireEvent.AddListener(OnFireEvent);
    }

    protected override void RemoveListeners()
    {
        InputController.fireEvent.RemoveListener(OnFireEvent);
    }

    void OnFireEvent(int i)
    {
        switch(i)
        {
            case 3:
                GameController.Instance.Transition<OverworldState>();
                break;
            default:
                break;
        }
    }
}
