using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//camera that follows rocket in command center view
public class RocketCameraBehavior : MonoBehaviour
{

    public SequencerManager SequencerBehavior;

    // rocket game objects
    public GameObject rocketBooster;
    public GameObject rocketBooster2;
    public GameObject mainRocket;

    //  Camera distance from rocket
    public Vector3 cameraOffset;

    public void Launch()
    {
        mainRocket.GetComponent<Animator>().Play("Liftoff");
        StartCoroutine("NextScreen");
    }

    void Update()
    {
        transform.position = rocketBooster.transform.position + cameraOffset;
    }

    //after rocket is launched boosters get detached. afer some time you go to next screen. TODO: Replace timer with win state.
    IEnumerator NextScreen()
    {
        yield return new WaitForSeconds(9f);
       //release boosters from rocket
        EnablePhysics(rocketBooster2);
        EnablePhysics(rocketBooster);
        rocketBooster.transform.parent = null;
        yield return new WaitForSeconds(16f);
        SequencerBehavior.SwitchScreens();
    }

    void EnablePhysics(GameObject GO)
    {
        //GO.GetComponent<Animator>().enabled = false;
        GO.transform.parent = null;
        GO.GetComponent<BoosterControl>().TurnOffBoostParticles();
        GO.GetComponent<Rigidbody>().isKinematic = false;
        GO.GetComponent<Rigidbody>().useGravity = true;
    }
}
