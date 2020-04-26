using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndGate : Block
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
            foreach (int i in inputs)
            {
                if (i == 0)
                {
                    return 0;
                }
            }
            return 1;
        }

        return 0;
    }
}
