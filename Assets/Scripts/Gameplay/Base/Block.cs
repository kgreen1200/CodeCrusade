using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int output = 0;
    public bool gate = false;

    public Block[] inputs;

    public virtual int CalculateOutput(int[] inputs)
    {
        return output;
    }
}
