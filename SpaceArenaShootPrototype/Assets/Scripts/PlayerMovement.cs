using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    public float acceleration = 25f;
    public float lateralAcceleration = 25f;
    public float maxSpeed = 100f;
    public float dashGain = 100f;
    public float dashTimer = 10;

    private Vector3 movement = Vector3.zero;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (movement != Vector3.zero)
        {
            rb.drag = 0;
            rb.AddForce(movement, ForceMode.Impulse);
        }
        else
        {
            //Drag proprio, ignorar o valor do rigidbody e deixar 0
            //TODO: não está correto, fica variando entre 0 e 1 quando devia parar
            //rb.AddForce(-rb.velocity.normalized * acceleration, ForceMode.Impulse);
            rb.drag = 1f;
        }
        movement = Vector3.zero;

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        Debug.Log("Vector :" + movement + " \nVelocity:" + rb.velocity.magnitude);
    }



    public void Stop()
    {
        movement -= rb.velocity.normalized * acceleration;
        
    }

    public void Accelerate()
    {
        movement += transform.forward * acceleration;
    }

    public void Reverse()
    {
        movement -= transform.forward * acceleration;
    }

    public void StrafeToLeft()
    {
        movement -= transform.right * lateralAcceleration;
    }

    public void StrafeToRight()
    {
        movement += transform.right * lateralAcceleration;
    }
}
