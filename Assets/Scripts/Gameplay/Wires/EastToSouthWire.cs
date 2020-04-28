using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EastToSouthWire : Wire
{
    // Called before Start()
    private void Awake()
    {
        onSprite = SpriteController.wireSprites[118];
        offSprite = SpriteController.wireSprites[96];
    }
}
