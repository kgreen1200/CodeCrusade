using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    public Sprite onSprite;
    public Sprite offSprite;
    public EndNode end;

    bool isInTriggerArea = false;
    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= startTime + 2f)
        {
            GetComponent<SpriteRenderer>().sprite = offSprite;
        }
        if (Input.GetButtonDown("Submit") && isInTriggerArea)
        {
            Debug.Log("Player has triggered lever.");
            this.gameObject.GetComponent<SpriteRenderer>().sprite = onSprite;
            end.OpenExit();
            startTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInTriggerArea = true;
        Debug.Log("Player has entered the trigger area");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInTriggerArea = false;
        Debug.Log("Player has left the trigger area");
    }
}
