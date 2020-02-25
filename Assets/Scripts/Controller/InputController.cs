using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static event EventHandler<InfoEventArgs<Point>> moveEvent;
    public static event EventHandler<InfoEventArgs<int>> fireEvent;

    string[] _buttons = new string[] { "Fire1", "Fire2", "Fire3" };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int x = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        int y = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));

        // Checks if keyboard input for movement is detected
        if (x != 0 || y != 0)
        {
            Move(new Point(x, y));
        }

        // Checks if each Fire button has been released
        for (int i = 0; i < 3; i++)
        {
            if (Input.GetButtonUp(_buttons[i]))
            {
                Fire(i);
            }
        }
    }

    // Calls moveEvent function if one is loaded in moveEvent
    void Move(Point p)
    {
        if (moveEvent != null)
            moveEvent(this, new InfoEventArgs<Point>(p));
    }

    // Calls fireEvent function if one is loaded in fireEvent
    void Fire(int i)
    {
        if (fireEvent != null)
            fireEvent(this, new InfoEventArgs<int>(i));
    }
}
