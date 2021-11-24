using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public float vehicleSpeed = 1.0f;
    public float maxSpeed;
    public float rotateSpeed = 10.0f;

    public bool grounded = false;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetVehicleForwardVelocity();
        RotateVehicle();
        CheckGrounded();
    }

    public void SetVehicleForwardVelocity()
    {
        if (grounded)
        {
            float forwardVel = Input.GetAxis("Vertical") * Time.deltaTime * vehicleSpeed;

            if (forwardVel >= maxSpeed)
            {
                rb.velocity = maxSpeed * transform.forward;
            }
            else
                rb.velocity = transform.forward * forwardVel;
        }

    }

    public void RotateVehicle()
    {
        if (grounded)
        {
            float rotation = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
            transform.Rotate(Vector3.up, rotation);
        }

    }

    public void CheckGrounded()
    {
        if(transform.position.y >= 1)
        {
            grounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I  ENTERED A TRIGGER");
        if(other.gameObject.CompareTag("collectible"))
        {
            Destroy(other.gameObject);
        }
    }



}
