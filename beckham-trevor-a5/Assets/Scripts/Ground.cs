using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ground : MonoBehaviour
{
    public int score;
    public int pointsValue;
    public int pointsMultiplier;
    public Text gameOverText;
    Lander lander = new Lander();


    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (lander.velocity < 0.5)
        {
            score += (pointsValue * pointsMultiplier);
            GameOver();
        }

    }

    public void GameOver()
    {
        if (lander.fuel == 0)
        {
            gameOverText.text = "The lander has ran out of fuel, hopefully the crew survives the impact" + "\n\n" + "Game Over";
        }

        if (lander.velocity > 0.5)
        {
            gameOverText.text = "The lander hit the ground too fast, it's been damaged beyond repair" + "\n\n" + "Game Over";
        }

        else
        {
            gameOverText.text = "Landing successful. One small step for man, one giant leap for mankind!";
        }
    }
}

