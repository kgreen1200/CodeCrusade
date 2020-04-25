using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayDescriptionPanel : MonoBehaviour
{
    static Text textField;

    // Called before Start()
    void Awake()
    {
        textField = GetComponentInChildren<Text>();
    }

    public static void SetText(string text)
    {
        textField.text = text;
    }
}
