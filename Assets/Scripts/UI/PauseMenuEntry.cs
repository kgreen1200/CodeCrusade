using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuEntry : MenuEntry
{
    PausePanel panel;

    // Start is called before the first frame update
    void Start()
    {
        panel = owner.GetComponent<PausePanel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void MouseEnter()
    {
        base.MouseEnter();
        panel.SetSelection(gameObject.GetComponent<Button>());
    }
}
