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

    // Called whenever object is enabled
    void OnEnable()
    {
        selection = 0;
        AddListeners();
        entries[selection].Select();
    }

    // Called whenever object is disabled
    void OnDisable()
    {
        RemoveListeners();
    }

    public void Play()
    {
        playPanel.SetActive(true);
        owner.SetActive(false);
    }

    public void Options()
    {
        optionPanel.SetActive(true);
        owner.SetActive(false);
    }

    public void Glossary()
    {
        glossaryPanel.SetActive(true);
        owner.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
