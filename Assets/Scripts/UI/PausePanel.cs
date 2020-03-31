using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePanel : BasePanel
{
    List<Button> entries = new List<Button>();
    int selection = 0;

    Dictionary<int, UnityEngine.Events.UnityAction> commands = new Dictionary<int, UnityEngine.Events.UnityAction>();

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
        commands.Add(0, Resume);
        commands.Add(1, Glossary);
        commands.Add(2, Save);
        commands.Add(3, Quit);

        for (int i = 0; i < entries.Count; i++)
        {
            entries[i].onClick.AddListener(commands[i]);
        }
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

    // For outside objects to set selection
    public void SetSelection(Button button)
    {
        selection = entries.IndexOf(button);
        entries[selection].Select();
    }

    public void Resume()
    {
        Debug.Log("Resume Here");
        GameController.Instance.Transition<OverworldState>();
    }

    public void Save()
    {
        Debug.Log("Save Here");
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
