using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class InputPanel : ButtonPanel
{
    [SerializeField]
    GameObject playPanel;

    GameObject owner;
    public InputField inputField;
    string text;
    Dictionary<int, UnityAction> commands = new Dictionary<int, UnityAction>();

    // Called before Start()
    void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Button button = transform.GetChild(i).gameObject.GetComponent<Button>();
            entries.Add(button);
        }

        owner = transform.parent.gameObject;
        inputField = owner.GetComponentInChildren<InputField>();
    }

    // Start is called before the first frame update
    void Start()
    {
        text = "default";
        
        commands.Add(0, Save);
        commands.Add(1, Cancel);

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
        inputField.onValueChanged.AddListener(ChangeText);
    }

    // Called whenever object is disabled
    void OnDisable()
    {
        inputField.onValueChanged.RemoveListener(ChangeText);
    }

    void ChangeText(string text)
    {
        this.text = text;
    }

    public void Save()
    {
        Game.current = new Game();
        Game.current.name = text;

        SceneManager.LoadScene("MainGameLevel", LoadSceneMode.Single);
    }

    public void Cancel()
    {
        owner.SetActive(false);
        playPanel.SetActive(true);
    }
}
