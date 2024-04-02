using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ground : MonoBehaviour
{
    public int score = 0;
    public int pointsValue = 0;
    public int pointsMultiplier = 1;


    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D collider)
    {

        score += pointsValue * pointsMultiplier;



    }
}
