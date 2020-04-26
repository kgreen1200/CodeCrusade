using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SouthToNorthWire : Wire
{
    // Called before Start()
    void Awake()
    {
        onSprite = SpriteController.wireSprites[25];
        offSprite = SpriteController.wireSprites[3];
    }
}
