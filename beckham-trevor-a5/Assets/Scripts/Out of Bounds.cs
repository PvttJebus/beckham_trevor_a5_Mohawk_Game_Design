using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OutofBounds : MonoBehaviour
{

    public Text oobText;
    public GameObject lunarLander;

    /*This idea came while I was building the teleporters. 
     Since it wouldn't make sense for the player to teleport down, nore for there to be a roof to a planet
     I made it possible for the player to fling their astronauts out into the void, left to float in the black forever*/
    private void OnTriggerEnter2D(Collider2D other)
    {
        lunarLander.SetActive(false);
        oobText.text = "The lander has left the moons gravity. Destined to forever float among the stars" +
            "\n\n" +
            "Game Over";
    }
}
