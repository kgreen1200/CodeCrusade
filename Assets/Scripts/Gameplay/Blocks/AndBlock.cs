﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndBlock : Block
{
    public WiringLogic Input1;
    public WiringLogic Input2;
    public Sprite OnState;
    public Sprite OffState;
    public bool OutputSignal = false;
    // Start is called before the first frame update
    void Start()
    {
        gate = true;
    }

    void Update()
    {
        OutputSignal = Input1.GetOutputSignal() && Input2.GetOutputSignal();
        if (OutputSignal)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = OnState;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = OffState;
        }
    }

    public bool GetOutputSignal()
    {
        return OutputSignal;
    }
}
