using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotBlock : Block
{
    // Start is called before the first frame update
    void Start()
    {
        gate = true;
    }

    public override int CalculateOutput(int[] inputs)
    {
        if (inputs.Length == 1)
        {
            return Mathf.Abs(inputs[0] - 1);
        }
        return 0;
    }
}
