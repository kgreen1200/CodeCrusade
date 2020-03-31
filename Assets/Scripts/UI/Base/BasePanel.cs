using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void AddListeners()
    {
        InputController.moveEvent.AddListener(OnMoveEvent);
        InputController.fireEvent.AddListener(OnFireEvent);
    }

    protected void RemoveListeners()
    {
        InputController.moveEvent.RemoveListener(OnMoveEvent);
        InputController.fireEvent.RemoveListener(OnFireEvent);
    }

    protected virtual void OnMoveEvent(Point p)
    {

    }

    protected virtual void OnFireEvent(int i)
    {

    }
}
