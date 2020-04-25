using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GridTile : MonoBehaviour
{
    public Block block = null;
    public LeverLogic lever = null;
    public GridTile[] inputs;

    Vector2 center;
    SpriteRenderer sprite;

    Color blue = new Color(0f, 0f, 1f, 0.4f);
    Color yellow = new Color(1f, 1f, 0f, 0.4f);

    void Start()
    {
        center = new Vector2(transform.position.x, transform.position.y);
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (lever == null && col.CompareTag("Block"))
        {
            col.transform.position = new Vector3(center.x, center.y, 0);
            block = col.GetComponent<Block>();
            sprite.color = yellow;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (block != null && col.CompareTag("Block"))
        {
            block = null;
            sprite.color = blue;
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
        if (block != null)
        {
            return block.CalculateOutput(GetInputs());
        }
        return 0;
    }
}
