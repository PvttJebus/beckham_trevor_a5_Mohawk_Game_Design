using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text scoreText;
    public int score = 0;
    Ground ground;

    void FixedUpdate()
    {
        DisplayScore();
    }

    public void AddScore()
    {
        score += ground.pointValue * ground.pointMultiplier;
      
    }

    public void DisplayScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
