using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterControl : MonoBehaviour
{
    public float throttle;

    public void Boost()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up*throttle);
        print("BOOOOST");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
