using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lander : MonoBehaviour
{
    public float thrustForce = 0;
    public float rotation = 0;
    public GameObject lander;
    public Rigidbody2D rb;
    public float drag;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        drag = rb.drag;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = Vector3.zero;

        bool upwardThrust = Input.GetKey(KeyCode.W);
        bool rotateLeft = Input.GetKey(KeyCode.A);
        bool rotateRight = Input.GetKey(KeyCode.D);

        if (upwardThrust)
        {
            thrustForce += 0.01f;
            rb.drag += 0.01f;
            offset.y += thrustForce;
            

        }

        if (rotateLeft)
            rotation++;
        
        if (rotateRight)
            rotation--;

        else if (rb.drag != 0 && thrustForce != 0)
        {


            thrustForce -= 0.01f;
            rb.drag -= 0.01f;
            offset.y += thrustForce;
            rotation = 0;
        }

        transform.position += offset * Time.deltaTime;
        transform.Rotate(transform.position, rotation);

    }
}
