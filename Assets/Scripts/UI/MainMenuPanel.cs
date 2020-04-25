using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainMenuPanel : ButtonPanel
{
    [SerializeField]
    GameObject playPanel, optionPanel, glossaryPanel;

    GameObject owner;
    Dictionary<int, UnityAction> commands = new Dictionary<int, UnityAction>();

    // Start is called before the first frame update
    void Start()
    {
        owner = transform.parent.gameObject;

        commands.Add(0, Play);
        commands.Add(1, Options);
        commands.Add(2, Glossary);
        commands.Add(3, ExitGame);

        for (int i = 0; i < entries.Count; i++)
        {
            entries[i].onClick.AddListener(commands[i]);
        }
    }

    public void Play()
    {
        owner.SetActive(false);
        playPanel.SetActive(true);
    }

    public void Options()
    {
        owner.SetActive(false);
        optionPanel.SetActive(true);
    }

    public void Glossary()
    {
        owner.SetActive(false);
        glossaryPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
