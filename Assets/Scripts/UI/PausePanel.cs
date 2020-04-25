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
        pause = true;

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
        if (Game.current != null)
        {
            List<Game> saves = SaveLoad.savedGames;
            if (saves.Contains(Game.current))
            {
                saves.Remove(Game.current);
            }
            SaveLoad.Save();
        }

        SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
    }

    public void Glossary()
    {
        gameObject.SetActive(false);
        glossaryPanel.SetActive(true);
    }

    public void Quit()
    {
        SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
    }
}
