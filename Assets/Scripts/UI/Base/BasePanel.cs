using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasePanel : MonoBehaviour
{
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
