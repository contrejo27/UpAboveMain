using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosterControl : MonoBehaviour
{
    //Throttle power
    public float throttle;
    Rigidbody rb;
    public GameObject boostParticles;

    //UI
    public Button boostButton;
    string direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void TurnOffBoostParticles()
    {
        boostParticles.SetActive(false);
    }

    public void Boost(string currentDirection)
    {
        direction = currentDirection;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if it touches land reduce movement and let it wobble. TODO: make it wobble more, if it falls trigger lose state
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
        //add boost up and a little tilt depending on which button you press
        if (direction == "left")
        {
            rb.AddForce(transform.up * throttle);
            rb.AddTorque(transform.right * throttle * .2f);
        }
        else if (direction == "right")
        {
            rb.AddForce(transform.up * throttle);
            rb.AddTorque(-transform.right * throttle * .2f);
        }
    }
}
