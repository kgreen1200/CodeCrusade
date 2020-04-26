using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpening : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite openSprite;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OpenGate()
    {
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = openSprite;
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
    }
}
