using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuEntry : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool selected = false;
    protected GameObject owner;

    // Called before Start()
    void Awake()
    {
        owner = transform.parent.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MouseExit();
    }

    protected virtual void MouseEnter()
    {
        selected = true;
    }

    protected virtual void MouseExit()
    {
        selected = false;
    }
}
