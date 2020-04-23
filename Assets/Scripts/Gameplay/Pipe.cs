using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public bool active;
    public Animator animator;
    public Pipe[] inputs;
    public Pipe[] outputs;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int CalcualateOutput(int[] inputs)
    {
        foreach (int input in inputs)
        {
            if (input == 0)
            {
                return 0;
            }
        }
        return 1;
    }
}
