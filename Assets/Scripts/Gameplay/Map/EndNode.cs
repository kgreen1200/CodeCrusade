using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EndNode : MonoBehaviour
{
    public GridTile[] inputs;
    public GameObject exit;
    public GameObject blockContainer;

    SpriteRenderer sprite;

    Color black = new Color(0f, 0f, 0f, 0.4f);
    Color red = new Color(1f, 0f, 0f, 0.4f);

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Clear()
    {
        for (int i = 0; i < blockContainer.transform.childCount; i++)
        {
            blockContainer.transform.GetChild(i).GetComponent<GridTile>().active = false;
        }
        sprite.color = black;
    }

    int[] GetInputs()
    {
        int[] arr = new int[inputs.Length];

        for (int i = 0; i < inputs.Length; i++)
        {
            arr[i] = inputs[i].CalculateOutput();
        }

        return arr;
    }

    public int CalculateOutput()
    {
        if (inputs.Length != 0)
        {
            foreach (int i in GetInputs())
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

    public bool CheckActive()
    {
        for (int i = 0; i < blockContainer.transform.childCount; i++)
        {
            if (!blockContainer.transform.GetChild(i).GetComponent<GridTile>().active)
            {
                return false;
            }
        }
        return true;
    }

    public bool OpenExit()
    {
        Clear();
        if (CalculateOutput() == 1 && CheckActive())
        {
            if (exit != null)
            {
                exit.GetComponent<GateOpening>().OpenGate();
            }
            sprite.color = red;
            return true;
        }
        return false;
    }
}
