using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpriteController
{
    public static Sprite[] wireSprites = Resources.LoadAll<Sprite>("WireSheet");
    public static Sprite[] andWireSprites = Resources.LoadAll<Sprite>("AndWireSheet");
    public static Sprite[] andSprites = Resources.LoadAll<Sprite>("AndBoxSheet");
    public static Sprite[] orSprites = Resources.LoadAll<Sprite>("OrBoxSheet");
}
