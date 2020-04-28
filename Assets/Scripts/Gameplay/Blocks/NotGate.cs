using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotGate : Block
{
    public Sprite OnState;
    public Sprite OffState;

    // Start is called before the first frame update
    void Start()
    {
        gate = true;
    }

    public override int CalculateOutput(int[] inputs)
    {
        if (inputs.Length != 0)
        {
            if (inputs[0] == 1)
            {
                Debug.Log("Return 0");
                return 0;
            }
            Debug.Log("Return 1");
            return 1;
        }
        return 0;
    }
}
