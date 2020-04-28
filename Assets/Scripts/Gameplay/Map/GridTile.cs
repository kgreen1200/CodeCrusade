using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GridTile : MonoBehaviour
{
    public Block block = null;
    public GameObject wires;
    public GridTile[] inputs;
    public bool active = false;

    Vector2 center;
    SpriteRenderer sprite;

    Sprite onSprite;
    Sprite offSprite;

    void Start()
    {
        center = new Vector2(transform.position.x, transform.position.y);
        sprite = GetComponent<SpriteRenderer>();
        offSprite = SpriteController.objectSprites[181];
        onSprite = SpriteController.objectSprites[182];
    }

    void TurnOnWires()
    {
        if (wires != null)
        {
            for (int i = 0; i < wires.transform.childCount; i++)
            {
                wires.transform.GetChild(i).GetComponent<Wire>().TurnOn();
            }
        }
    }

    void TurnOffWires()
    {
        if (wires != null)
        {
            for (int i = 0; i < wires.transform.childCount; i++)
            {
                wires.transform.GetChild(i).GetComponent<Wire>().TurnOff();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Block"))
        {
            col.transform.position = new Vector3(center.x, center.y, 0);
            block = col.GetComponent<Block>();
            sprite.sprite = onSprite;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (block != null && col.CompareTag("Block"))
        {
            block = null;
            sprite.sprite = offSprite;
        }
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
        TurnOffWires();
        if (block != null)
        {
            int output = block.CalculateOutput(GetInputs());
            if (output == 1)
            {
                TurnOnWires();
                active = true;
            }
            if (!block.gate)
            {
                active = true;
            }
            return output;
        }
        GetInputs();
        return 0;
    }
}
