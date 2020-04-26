using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WestToSouthWire : Wire
{
    // Called before Start()
    void Awake()
    {
        onSprite = SpriteController.wireSprites[28];
        offSprite = SpriteController.wireSprites[6];
    }
}
