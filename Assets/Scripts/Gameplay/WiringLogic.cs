using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiringLogic : MonoBehaviour
{

    public LeverLogic Lever;
    public WiringLogic PreviousWire;
    public bool DoesConnectToLever = true;
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
        if (DoesConnectToLever && OutputSignal != Lever.GetOutputSignal())
        {
            OutputSignal = Lever.GetOutputSignal();
            Debug.Log("Wire Output signal has been swapped");
            if (OutputSignal == true)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = OnSprite;
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = OffSprite;
            }
        }
        else if (!DoesConnectToLever)
        {
            if (OutputSignal != PreviousWire.GetOutputSignal())
            {
                OutputSignal = Lever.GetOutputSignal();
                Debug.Log("Wire Output signal has been swapped");
                if (OutputSignal == true)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = OnSprite;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = OffSprite;
                }
            }
        }
    }

    public bool GetOutputSignal()
    {
        return OutputSignal;
    }
}
