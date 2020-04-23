using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotBlock : Block
{
    public WiringLogic Input1;
    public Sprite OnState;
    public Sprite OffState;
    public bool OutputSignal = true;
    // Start is called before the first frame update
    void Start()
    {
        gate = true;
    }

    private void Update()
    {
        OutputSignal = !Input1.GetOutputSignal();
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
