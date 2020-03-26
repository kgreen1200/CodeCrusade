using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToSample : MonoBehaviour
{
    private int pressCount;
    // Start is called before the first frame update
    void Start()
    {
        pressCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            pressCount = pressCount + 1;
            Debug.Log("PressCount is now " + pressCount);
            if (pressCount == 3) {
                Debug.Log("Loading new scene");
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            }
        }
    }
}
