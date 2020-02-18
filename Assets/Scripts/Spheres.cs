using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spheres : MonoBehaviour
{
    public float gameSpeed = 50.0f;
    Rigidbody rb = null;
    bool jumped = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.running)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(-gameSpeed/2, 0, 0);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(gameSpeed/2, 0, 0);
            }
            if(rb.velocity.z < gameSpeed)
            {
                rb.AddForce(0, 0, gameSpeed - rb.velocity.z);
            }
            if(Input.GetKey(KeyCode.Space) && !jumped)
            {
                rb.AddForce(0, 20, 0);
            }
            if(rb.velocity.y  < 0.5)
            {
                jumped = false;
            }

            Debug.Log(rb.velocity.y);
        }
    }
}
