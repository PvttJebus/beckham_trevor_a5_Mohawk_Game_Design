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
    public Lander lander;
    public GameObject lunarLander;
    public float safeLandingSpeed;


    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log($"landing velocity {lander.velocity} - safe landing speed {safeLandingSpeed}");
        if (lander.velocity <= safeLandingSpeed)
        {
            score += (pointsValue * pointsMultiplier);
            gameOverText.text = "Landing successful. One small step for man, one giant leap for mankind!";
        }

        //if (lander.velocity > safeLandingSpeed)
        else
        {
            gameOverText.text = "The lander hit the ground too fast, it's been damaged beyond repair" + "\n\n" + "Game Over";
            lunarLander.SetActive(false);
        }
    }
}
