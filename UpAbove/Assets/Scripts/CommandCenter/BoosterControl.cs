using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosterControl : MonoBehaviour
{
    public float throttle;
    Rigidbody rb;
    public Button boostButton;
    string direction;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Boost(string currentDirection)
    {
        direction = currentDirection;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name == "Land")
        {
            print("Safely landed");
            rb.velocity = Vector3.zero;
            rb.angularVelocity= Vector3.zero;

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (direction == "left")
        {
            rb.AddForce(transform.up * throttle);
            rb.AddTorque(transform.forward * throttle * .2f);
        }
        else if (direction == "right")
        {
            rb.AddForce(transform.up * throttle);
            rb.AddTorque(-transform.forward * throttle * .2f);
        }
    }
}
