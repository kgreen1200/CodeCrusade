using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaveOptionsPanel : ButtonPanel
{
    [SerializeField]
    GameObject mainPanel;

    GameObject owner;
    Dictionary<int, UnityAction> commands = new Dictionary<int, UnityAction>();

    // Start is called before the first frame update
    void Start()
    {
        owner = transform.parent.gameObject;
        
        commands.Add(0, Load);
        commands.Add(1, Delete);
        commands.Add(2, ExitMenu);

        for (int i = 0; i < entries.Count; i++)
        {
            entries[i].onClick.AddListener(commands[i]);
        }
    }

    public void Load()
    {
        Debug.Log("Load game here");
    }

    public void Delete()
    {
        Debug.Log("Delete save file here");
    }

    public void ExitMenu()
    {
        mainPanel.SetActive(true);
        owner.SetActive(false);
    }
}
