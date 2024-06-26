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
    public Text velocityText;
    public float thrustForce = 0;
    public float rotationSpeed = 0;
    public float rotation = 0;
    public Ground ground;
    Vector2 force;
    public GameObject lander;
    public Rigidbody2D rb;
    public float fuel = 100;
    public Text fuelText;
    public Image thrust;
    public float velocity;
    public Text gameOverText;
    public bool landerIsActive = true;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.gravity = new Vector2(0, -1.6f);
        thrust.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Found out if you make this if loop a while loop, it'll make you think you broke your computer...
        if (landerIsActive)
        {
            Movement();
            OutOfFuel();
        }

        Reset();
        //I originally had these on the ground script, but found it wasn't updating. Likely because I didn't think to add the update function to that script. Live and learn.
        fuelText.text = "Fuel: " + fuel.ToString("0");
        scoreText.text = "Score: " + ground.score.ToString();
        velocityText.text = "Velocity: " + velocity.ToString("0.00");
    }


    public void Movement()
    {
        Vector3 offset = Vector3.zero;
        force = transform.up * thrustForce;

        /*THIS LINE OF CODE MAN... I was rackin my brain trying to understand how to track the downward velocity, 
         * just goes to show how complex Unity and how long it's been since I've thought about math stuff*/
        velocity = rb.velocity.magnitude;

        bool upwardThrust = Input.GetKey(KeyCode.W);
        bool rotateLeft = Input.GetKey(KeyCode.A);
        bool rotateRight = Input.GetKey(KeyCode.D);

        if (upwardThrust && fuel >= 0)
        {
            //offset = transform.up * thrustForce;
            rb.AddForce(force);
            fuel -= 1.5f * Time.deltaTime;
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


    public void OutOfFuel()
    {
        if (fuel <= 0)
        {
            gameOverText.text = "The lander has ran out of fuel,";
        }
    }


    public void Reset()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Debug.Log("R Key was Pressed");
            ground.GameRestart();
            landerIsActive = true;
        }
    }
}

/* The code graveyard... tho this case was because I thought I was gonna bork the script so I copied it all then held Ctrl-Z to revert all changes to the original state.
 * So the below is a backup for future outdated code I guess. */

//public class Lander : MonoBehaviour
//{
//    public float thrustForce = 0;
//    public float rotationSpeed = 0;
//    public float rotation = 0;
//    Vector2 force;
//    Ground ground;
//    public GameObject lander;
//    public Rigidbody2D rb;
//    public float fuel = 100;
//    public Text fuelText;
//    public Image thrust;
//    public float velocity;
//    public Text gameOverText;


//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        Physics2D.gravity = new Vector2(0, -1.6f);
//        thrust.enabled = false;
//    }

//    // Update is called once per frame
//    void FixedUpdate()
//    {

//        Movement();
//        OutOfFuel();
//        Reset();



//    }


//    public void Movement()
//    {
//        fuelText.text = "Fuel: " + fuel.ToString("0");
//        Vector3 offset = Vector3.zero;
//        force = transform.up * thrustForce;
//        velocity = rb.velocity.magnitude;

//        bool upwardThrust = Input.GetKey(KeyCode.W);
//        bool rotateLeft = Input.GetKey(KeyCode.A);
//        bool rotateRight = Input.GetKey(KeyCode.D);

//        if (upwardThrust && fuel >= 0)
//        {
//            //offset = transform.up * thrustForce;
//            rb.AddForce(force);
//            fuel -= 1.0f * Time.deltaTime;
//            thrust.enabled = !thrust.enabled;



//        }

//        if (rotateLeft)
//            rotation += rotationSpeed * Time.deltaTime;

//        if (rotateRight)
//            rotation -= rotationSpeed * Time.deltaTime;


//        transform.position += offset * Time.deltaTime;
//        thrust.transform.position = transform.position;
//        transform.Rotate(0, 0, rotation);
//        thrust.transform.Rotate(0, 0, rotation);
//    }


//    public void OutOfFuel()
//    {
//        if (fuel == 0)
//        {
//            gameOverText.text = "The lander has ran out of fuel, hopefully the crew survives the impact" + "\n\n" + "Game Over";
//        }
//    }


//    public void Reset()
//    {
//        if (Input.GetKey(KeyCode.R))
//        {
//            Debug.Log("R Key was Pressed");
//            ground.GameRestart();
//        }



//    }
//}




