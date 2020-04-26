using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEastWire : Wire
{
    // Called before Start()
    void Awake()
    {
        onSprite = SpriteController.andWireSprites[158];
        offSprite = SpriteController.andWireSprites[133];
    }
}
