using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SaveOptionsPanel : ButtonPanel
{
    [SerializeField]
    GameObject mainPanel, inputPanel, descriptionPanel, container;

    GameObject owner;
    public Text description;
    Button buttonPrefab;
    Dictionary<int, UnityAction> commands = new Dictionary<int, UnityAction>();

    // Called before Start()
    void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Button button = transform.GetChild(i).gameObject.GetComponent<Button>();
            entries.Add(button);
        }

        buttonPrefab = Resources.Load<Button>("UI/Button");
        SaveLoad.Load();
    }

    // Start is called before the first frame update
    void Start()
    {
        owner = transform.parent.gameObject;
        description = descriptionPanel.GetComponentInChildren<Text>();

        commands.Add(0, NewGame);
        commands.Add(1, Load);
        commands.Add(2, Delete);
        commands.Add(3, ExitMenu);

        for (int i = 0; i < entries.Count; i++)
        {
            entries[i].onClick.AddListener(commands[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Next();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Previous();
        }
    }

    // Called whenever object is enabled
    void OnEnable()
    {
        Game.current = null;
        selection = 0;
        AddListeners();
        entries[selection].Select();

        Populate();
    }

    void OnDisable()
    {
        RemoveListeners();
        DePopulate();
    }

    void Populate()
    {
        foreach (Game game in SaveLoad.savedGames)
        {
            Button obj = Instantiate(buttonPrefab);
            obj.transform.SetParent(container.transform, false);
            obj.GetComponent<SaveEntry>().save = game;
            obj.GetComponentInChildren<Text>().text = game.name;
        }
    }

    void DePopulate()
    {
        for (int i = container.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(container.transform.GetChild(i).gameObject);
        }
    }

    public void NewGame()
    {
        owner.SetActive(false);
        inputPanel.SetActive(true);
    }

    public void Load()
    {
        if (Game.current != null)
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
        else
        {
            PlayDescriptionPanel.SetText("No save file has been selected to load.");
        }
    }

    public void Delete()
    {
        Debug.Log("Delete save file here");
        if (Game.current != null)
        {
            SaveLoad.savedGames.Remove(Game.current);
            Game.current = null;
            DePopulate();
            Populate();
        }
        else
        {
            PlayDescriptionPanel.SetText("No save file has been selected to delete.");
        }
    }

    public void ExitMenu()
    {
        mainPanel.SetActive(true);
        owner.SetActive(false);
    }
}
