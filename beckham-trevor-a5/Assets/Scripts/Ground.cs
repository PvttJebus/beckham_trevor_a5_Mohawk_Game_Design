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
    public Vector3 beginningRotation;


    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log($"landing velocity {lander.velocity} - safe landing speed {safeLandingSpeed}");
        score += (pointsValue * pointsMultiplier);

        if (lander.fuel != 0)
        {
            gameOverText.text = "Landing successful. One small step for man, one giant leap for mankind!" + "\n\n" + "There is still fuel left, press R to reset and get more points!";
        }

        else
        {
            gameOverText.text = "Landing successful. One small step for man, one giant leap for mankind!" + "\n\n" + $"Fuel reserves depleted, you achieved {score}";
        }
    }

   
    public void GameRestart()
    {

        Rigidbody2D rg2d = lunarLander.GetComponent<Rigidbody2D>();
        rg2d.position = new Vector3(-18.3600006f, 11.6099997f, 1.78970003f);
        lander.transform.Rotate(beginningRotation);
        gameOverText.text = "";
        
    }
}
