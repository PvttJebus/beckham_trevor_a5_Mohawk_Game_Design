using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 teleportLocation;
    public GameObject lander;

    private void OnTriggerEnter2D(Collider2D other)
    { 
        lander.transform.position = teleportLocation;
    }

    
}
