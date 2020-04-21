using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverLogic : MonoBehaviour
{

    public BoxCollider2D TriggerCollider;
    public Sprite OnSprite;
    public Sprite OffSprite;
    private bool OutputSignal = false;
    private bool IsInTriggerArea = false;
    private float StartTime;

    // Start is called before the first frame update
    void Start()
    {
        if (TriggerCollider.isTrigger)
        {
            Debug.Log("This collider is a trigger.");
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (OutputSignal == true && Time.time >= StartTime + 2f)
        {
            OutputSignal = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = OffSprite;
            Debug.Log("Lever Output signal set to false.");
        }
        if (Input.GetButtonDown("Submit") && IsInTriggerArea)
        {
            Debug.Log("Player has triggered lever.");
            if (OutputSignal == false)
            {
                OutputSignal = true;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = OnSprite;
                Debug.Log("Lever Output signal set to true.");
                StartTime = Time.time;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsInTriggerArea = true;
        Debug.Log("Player has entered the trigger area");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsInTriggerArea = false;
        Debug.Log("Player has left the trigger area");
    }

    public bool GetOutputSignal()
    {
        return OutputSignal;
    }
}
