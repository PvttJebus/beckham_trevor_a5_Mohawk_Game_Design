using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class multiply : MonoBehaviour
{
    public Ground ground;
    public Text gameOverText;
    public Lander lander;
    public GameObject lunarLander;
    public float safeLandingSpeed;
    public int pointValue;
    public int pointMultiplier;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log($"landing velocity {lander.velocity} - safe landing speed {safeLandingSpeed}");
        if (lander.landerIsActive)
        {
            ground.score += (pointValue * pointMultiplier);


            if (lander.fuel != 0 && lander.velocity < safeLandingSpeed)
            {
                gameOverText.text = "Landing successful. One small step for man, one giant leap for mankind!" + "\n\n" + "There is still fuel left, press R to reset and get more points!";
                lander.landerIsActive = false;
            }

            else
            {
                gameOverText.text = "Landing successful. One small step for man, one giant leap for mankind!" + "\n\n" + $"Fuel reserves depleted, you achieved {ground.score}";
                lander.landerIsActive = false;
            }

            if (lander.velocity > safeLandingSpeed)
            {
                gameOverText.text = "The lander hit the surface too fast, it's damaged beyond repair. The astronauts are stranded." + "\n\n" + $"Final Score: {ground.score}";
                lander.landerIsActive = false;
                lunarLander.SetActive(false);
            }
        }
    }
}
