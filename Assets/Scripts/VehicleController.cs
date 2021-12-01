using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public float vehicleSpeed = 1.0f;
    public float maxSpeed;
    public float rotateSpeed = 10.0f;

    public Transform bulletSpawn;

    public GameObject projectile;

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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            FireProjectile();
        }
    }

    public void FireProjectile()
    {
        GameObject go = Instantiate<GameObject>(projectile);
        go.transform.position = bulletSpawn.position;
        go.transform.rotation = transform.rotation;
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
        if(other.gameObject.CompareTag("collectible"))
        {
            Destroy(other.gameObject);
        }
    }



}
