using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ground : MonoBehaviour
{
    public int score;
    public int pointValue;
    public int pointMultiplier;
    public Text gameOverText;
    public Lander lander;
    public GameObject lunarLander;
    public float safeLandingSpeed;
    //public Vector3 beginningRotation;


    /*My original intent was to have all of the ground multiplication and such on one script, but after trying to break score off and breaking things
     I decided to just create two cripts, one for score & "Normal" ground and another for the multipliers.*/
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log($"landing velocity {lander.velocity} - safe landing speed {safeLandingSpeed}");
        if (lander.landerIsActive)
        {
            score += (pointValue * pointMultiplier);

            if (lander.fuel != 0 && lander.velocity < safeLandingSpeed)
            {
                gameOverText.text = "Landing successful. One small step for man, one giant leap for mankind!" + "\n\n" + "There is still fuel left, press R to reset and get more points!";
                lander.landerIsActive = false;
            }

            if (lander.fuel <= 0 && lander.velocity < safeLandingSpeed)
            {
                gameOverText.text = "Landing successful. One small step for man, one giant leap for mankind!" + "\n\n" + $"Fuel reserves depleted, you achieved a total score of {score}";
                lander.landerIsActive = false;
            }

            if (lander.velocity > safeLandingSpeed)
            {
                gameOverText.text = "The lander hit the surface too fast, it's damaged beyond repair. The astronauts are stranded." + "\n\n" + $"Final Score: {score}";
                lander.landerIsActive = false;
                lunarLander.SetActive(false);
            }
        }
    }


    public void GameRestart()
    {

        /* So this is my attempt at a quick restart, and it works... almosty perfectly.
         * The big issue is that even after trying to reset the rotation of the lander upon restart, it wouldn't revert back to the starting point, I tried a few different methods for this. 
         * So now, the extra rotation on retries is just a totally intentional difficulty spike to make the next attempts harder!*/
        Rigidbody2D rg2d = lunarLander.GetComponent<Rigidbody2D>();
        rg2d.position = new Vector3(-18.3600006f, 11.6099997f, 1.78970003f);
        //lander.transform.Rotate(beginningRotation);
        gameOverText.text = "";

    }
}
