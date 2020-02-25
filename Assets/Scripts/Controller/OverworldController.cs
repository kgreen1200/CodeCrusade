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
        InputController.moveEvent += OnMoveEvent;
        InputController.fireEvent += OnFireEvent;
    }

    // OnDisable is called whenver object is disabled
    void OnDisable()
    {
        // Unloads functions from InputController
        InputController.moveEvent -= OnMoveEvent;
        InputController.fireEvent -= OnFireEvent;
    }

    // Custom OnMoveEvent triggered from InputController
    void OnMoveEvent(object sender, InfoEventArgs<Point> e)
    {
        player.SetChange(e.info.x, e.info.y);
    }

    // Custom OnFireEvent triggered from InputController
    void OnFireEvent(object sender, InfoEventArgs<int> e)
    {
        Debug.Log("Fire " + e.info);
    }
}
