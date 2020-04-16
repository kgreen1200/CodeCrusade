using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PausePanel : ButtonPanel
{
    Dictionary<int, UnityAction> commands = new Dictionary<int, UnityAction>();

    // Start is called before the first frame update
    void Start()
    {
        commands.Add(0, Resume);
        commands.Add(1, Glossary);
        commands.Add(2, Save);
        commands.Add(3, Quit);

        for (int i = 0; i < entries.Count; i++)
        {
            entries[i].onClick.AddListener(commands[i]);
        }
    }

    public void Resume()
    {
        Debug.Log("Resume Here");
        GameController.Instance.Transition<OverworldState>();
    }

    public void Save()
    {
        SaveLoad.Save();
    }

    public void Glossary()
    {
        Debug.Log("Glossary Here");
    }

    public void Quit()
    {
        Debug.Log("Quit Here");
        Debug.Log("Loading to Main Menu");
        SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
    }
}
