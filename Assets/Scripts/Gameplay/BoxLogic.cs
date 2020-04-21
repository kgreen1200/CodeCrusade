using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLogic : MonoBehaviour
{
    public bool CanDetectNorth = false;
    public bool CanDetectSouth = false;
    public bool CanDetectEast = false;
    public bool CanDetectWest = false;
    public string LogicType = "AND";

    public bool outputState = false;
    public string outputDirection = "NORTH";

    /*
     * AND
     * OR
     * NOT
     * XOR
     * NOR
     */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
