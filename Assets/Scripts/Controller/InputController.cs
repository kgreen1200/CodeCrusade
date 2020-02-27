using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static CustomEvent<Point> moveEvent = new CustomEvent<Point>();
    public static CustomEvent<int> fireEvent = new CustomEvent<int>();

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

        Move(new Point(x, y));

        // Checks if each Fire button has been released
        for (int i = 0; i < 3; i++)
        {
            if (Input.GetButtonUp(_buttons[i]))
            {
                Fire(i);
            }
        }
    }

    // Invoke events stored in moveEvent
    void Move(Point p)
    {
        if (moveEvent != null)
            moveEvent.Invoke(p);
    }

    // Invoke events stored in fireEvent
    void Fire(int i)
    {
        if (fireEvent != null)
            fireEvent.Invoke(i);
    }
}
