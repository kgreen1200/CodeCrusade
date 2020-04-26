using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WestToEastWire : Wire
{
    // Called before Start()
    void Awake()
    {
        onSprite = SpriteController.wireSprites[22];
        offSprite = SpriteController.wireSprites[0];
    }
}
