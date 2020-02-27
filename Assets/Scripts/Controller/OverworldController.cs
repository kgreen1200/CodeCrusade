using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller for player behavior in the Overworld State
public class OverworldController : MonoBehaviour
{
    public GameObject playerObj;
    PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = playerObj.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // OnEnable is called whenever object is enabled (including on start if enabled)
    void OnEnable()
    {
        // Loads functions into InputController
        InputController.moveEvent.AddListener(OnMoveEvent);
        InputController.fireEvent.AddListener(OnFireEvent);
    }

    // OnDisable is called whenver object is disabled
    void OnDisable()
    {
        // Unloads functions from InputController
        InputController.moveEvent.RemoveListener(OnMoveEvent);
        InputController.fireEvent.RemoveListener(OnFireEvent);
    }

    // Custom OnMoveEvent triggered from InputController
    void OnMoveEvent(Point p)
    {
        player.SetChange(p.x, p.y);
    }

    // Custom OnFireEvent triggered from InputController
    void OnFireEvent(int i)
    {
        Debug.Log("Fire " + i);
    }
}
