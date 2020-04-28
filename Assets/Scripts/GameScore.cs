using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public int scoreDecrement = 10;
    public int maxScore = 5000;
    public int baseCompletionPoints = 20;

    private int levelsCompleted = 0;
    private int score;
    private float timer;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        score = maxScore;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime; // Add the change in time;
        if (timer > 5f && score != 0)
        {
            score -= scoreDecrement;
            scoreText.text = score.ToString();
            timer = 0;
        }
    }

    public void completeLevel()
    {
        score += baseCompletionPoints + 10 * levelsCompleted;
        levelsCompleted += 1;
    }
}
