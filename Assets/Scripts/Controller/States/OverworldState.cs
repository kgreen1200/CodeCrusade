using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller for player behavior in the Overworld State
public class OverworldState : State
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // OnEnable is called whenever object is enabled (including on start if enabled)
    protected override void AddListeners()
    {
        // Loads functions into InputController
        InputController.moveEvent.AddListener(OnMoveEvent);
        InputController.fireEvent.AddListener(OnFireEvent);
    }

    // OnDisable is called whenver object is disabled
    protected override void RemoveListeners()
    {
        // Unloads functions from InputController
        InputController.moveEvent.RemoveListener(OnMoveEvent);
        InputController.fireEvent.RemoveListener(OnFireEvent);
    }

    // Custom OnMoveEvent triggered from InputController
    void OnMoveEvent(Point p)
    {
        PlayerMovement.Instance.SetChange(p.x, p.y);
    }

    // Custom OnFireEvent triggered from InputController
    void OnFireEvent(int i)
    {
        Debug.Log("Fire " + i);
    }
}
