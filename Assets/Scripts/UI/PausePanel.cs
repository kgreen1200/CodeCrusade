using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PausePanel : ButtonPanel
{
    [SerializeField]
    GameObject glossaryPanel;

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

    // Called whenever object is enabled
    void OnEnable()
    {
        selection = 0;
        AddListeners();
        entries[selection].Select();
        Time.timeScale = 0f;
    }

    // Called whenever object is disabled
    void OnDisable()
    {
        RemoveListeners();
        Time.timeScale = 1f;
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
        glossaryPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Quit()
    {
        SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
    }
}
