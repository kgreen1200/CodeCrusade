using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Wire : MonoBehaviour
{
    protected Sprite onSprite;
    protected Sprite offSprite;

    protected SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        TurnOff();
    }

    public void TurnOn()
    {
        sprite.sprite = onSprite;
    }

    public void TurnOff()
    {
        sprite.sprite = offSprite;
    }
}
