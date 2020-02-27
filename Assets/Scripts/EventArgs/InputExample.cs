using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // OnEnable is called whenever gameobject is enabled (including on startup)
    void OnEnable()
    {
        InputController.moveEvent.AddListener(OnMoveEvent);
        InputController.fireEvent.AddListener(OnFireEvent);
    }

    // OnDisable is called whenever gameobject is disabled
    void OnDisable()
    {
        InputController.moveEvent.RemoveListener(OnMoveEvent);
        InputController.fireEvent.RemoveListener(OnFireEvent);
    }

    // Custom OnMoveEvent
    void OnMoveEvent(Point p)
    {
        Debug.Log("Move " + p.x + ", " + p.y);
    }

    // Custom OnFireEvent
    void OnFireEvent(int i)
    {
        Debug.Log("Fire " + i);
    }

}
