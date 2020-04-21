using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExitToMainMenuPanel : ButtonPanel
{
    [SerializeField]
    GameObject mainPanel;

    GameObject owner;
    Dictionary<int, UnityAction> commands = new Dictionary<int, UnityAction>();

    // Start is called before the first frame update
    void Start()
    {
        owner = transform.parent.gameObject;

        commands.Add(0, ExitMenu);

        for (int i = 0; i < entries.Count; i++)
        {
            entries[i].onClick.AddListener(commands[i]);
        }
    }

    public void ExitMenu()
    {
        mainPanel.SetActive(true);
        owner.SetActive(false);
    }
}
