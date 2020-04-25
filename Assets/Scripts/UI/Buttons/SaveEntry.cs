using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveEntry : MonoBehaviour
{
    public Game save;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SetGame);
    }

    void SetGame()
    {
        Game.current = save;
        PlayDescriptionPanel.SetText(save.name + " has been selected.");
    }
}
