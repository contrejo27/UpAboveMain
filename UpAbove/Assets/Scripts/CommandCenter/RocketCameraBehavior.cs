using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCameraBehavior : MonoBehaviour
{
    public SequencerManager SequencerBehavior;
    public GameObject rocketBooster;
    public GameObject rocketBooster2;
    public GameObject mainRocket;

    public Vector3 cameraOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Launch()
    {
        mainRocket.GetComponent<Animator>().Play("Liftoff");
        StartCoroutine("NextScreen");
    }

    void Update()
    {
        transform.position = rocketBooster.transform.position + cameraOffset;
    }
    IEnumerator NextScreen()
    {
        yield return new WaitForSeconds(9f);
        print("dropoff");
        EnablePhysics(rocketBooster2);
        rocketBooster2.transform.parent = null;
        EnablePhysics(rocketBooster);
        rocketBooster.transform.parent = null;
        yield return new WaitForSeconds(16f);
        SequencerBehavior.SwitchScreens();
    }

     void EnablePhysics(GameObject GO)
    {
        GO.GetComponent<Animator>().enabled = false;
        GO.GetComponent<Rigidbody>().isKinematic = false;
        GO.GetComponent<Rigidbody>().useGravity = true;

    }
}
