using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OutofBounds : MonoBehaviour
{

    public Text oobText;
    public GameObject lunarLander;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        lunarLander.SetActive(false);
        oobText.text = "The lander has left the moons gravity. Destined to forever float among the stars" +
            "\n\n" +
            "Game Over";
    }
}
