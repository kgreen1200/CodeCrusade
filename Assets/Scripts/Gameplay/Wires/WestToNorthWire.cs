using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WestToNorthWire : Wire
{
    // Called before Start()
    void Awake()
    {
        onSprite = SpriteController.wireSprites[82];
        offSprite = SpriteController.wireSprites[60];
    }
}
