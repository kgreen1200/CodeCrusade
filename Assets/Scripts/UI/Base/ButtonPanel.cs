using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPanel : BasePanel
{
    protected List<Button> entries = new List<Button>();
    protected int selection = 0;

    // Called before Start()
    void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Button button = transform.GetChild(i).gameObject.GetComponent<Button>();
            entries.Add(button);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Next();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Previous();
        }
    }

    // Cycle down menu
    void Next()
    {
        selection = (selection + 1 < entries.Count) ? (selection + 1) : 0;
        entries[selection].Select();
    }

    // Cycle up menu
    void Previous()
    {
        selection = (selection - 1 >= 0) ? (selection - 1) : (entries.Count - 1);
        entries[selection].Select();
    }

    // Call onClick functions when Fired
    protected override void OnFireEvent(int i)
    {
        switch(i)
        {
            case 0:
                entries[selection].onClick.Invoke();
                break;
            default:
                break;
        }
    }

    // For outside objects to set selection
    public void SetSelection(Button button)
    {
        selection = entries.IndexOf(button);
        entries[selection].Select();
    }
}
