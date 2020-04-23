using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiringLogic : MonoBehaviour
{

    public LeverLogic Lever;
    public WiringLogic PreviousWire;
    public AndBlock AndGate;
    public OrBlock OrGate;
    public NotBlock NotGate;

    public string InputType = "WIRE";

    public Sprite OnSprite;
    public Sprite OffSprite;
    private bool OutputSignal = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch(InputType)
        {
            case "WIRE":
                OutputSignal = PreviousWire.GetOutputSignal();
                break;
            case "LEVER":
                OutputSignal = Lever.GetOutputSignal();
                break;
            case "AND_GATE":
                OutputSignal = AndGate.GetOutputSignal();
                break;
            case "OR_GATE":
                OutputSignal = OrGate.GetOutputSignal();
                break;
            case "NOT_GATE":
                OutputSignal = NotGate.GetOutputSignal();
                break;
        }

        // Updates the sprite for the wire based on its updated state.
        if (OutputSignal)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = OnSprite;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = OffSprite;
        }
    }

    public bool GetOutputSignal()
    {
        return OutputSignal;
    }
}
