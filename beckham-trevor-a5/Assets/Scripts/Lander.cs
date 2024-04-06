using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Lander : MonoBehaviour
{
    public Text scoreText;
    public float thrustForce = 0;
    public float rotationSpeed = 0;
    public float rotation = 0;
    Vector2 force;
    public GameObject lander;
    public Rigidbody2D rb;
    public float fuel = 100;
    public Text fuelText;
    public Image thrust;
    public float velocity;
    public Text gameOverText;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.gravity = new Vector2(0, -1.6f);
        thrust.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }


    public void Movement()
    {
        Ground ground = new Ground();
        fuelText.text = "Fuel: " + fuel.ToString("0");
        scoreText.text = "Score: " + ground.score;
        Vector3 offset = Vector3.zero;
        force = transform.up * thrustForce;
        velocity = rb.velocity.magnitude;

        bool upwardThrust = Input.GetKey(KeyCode.W);
        bool rotateLeft = Input.GetKey(KeyCode.A);
        bool rotateRight = Input.GetKey(KeyCode.D);

        if (upwardThrust && fuel >= 0)
        {
            //offset = transform.up * thrustForce;
            rb.AddForce(force);
            fuel -= 1.0f * Time.deltaTime;
            thrust.enabled = !thrust.enabled;



        }

        if (rotateLeft)
            rotation += rotationSpeed * Time.deltaTime;

        if (rotateRight)
            rotation -= rotationSpeed * Time.deltaTime;


        transform.position += offset * Time.deltaTime;
        thrust.transform.position = transform.position;
        transform.Rotate(0, 0, rotation);
        thrust.transform.Rotate(0, 0, rotation);
    }

   
}
