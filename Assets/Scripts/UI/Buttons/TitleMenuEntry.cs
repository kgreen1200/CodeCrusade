using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleMenuEntry : MenuEntry
{
    ButtonPanel panel;

    // Start is called before the first frame update
    void Start()
    {
        panel = owner.GetComponent<ButtonPanel>();
    }

    protected override void MouseEnter()
    {
        base.MouseEnter();
        panel.SetSelection(gameObject.GetComponent<Button>());
    }
}
