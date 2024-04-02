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


    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D collider)
    {
        score += (pointsValue * pointsMultiplier);

    }
}
