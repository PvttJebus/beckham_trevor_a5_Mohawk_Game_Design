using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    /*This was a fun one to figure out. Knowing the player would likely fly out of range, I didn't want to just have them veer off
     So now they just circumnavigate the planet REALLY fast and appear on the other side of the screen*/

    public Vector3 teleportLocation;
    public GameObject lander;

    private void OnTriggerEnter2D(Collider2D other)
    {
        lander.transform.position = teleportLocation;
    }


}
