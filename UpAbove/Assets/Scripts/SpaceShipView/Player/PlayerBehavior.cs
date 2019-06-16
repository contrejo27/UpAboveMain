using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    float sightDistance = 40f;
    public float fadeRate;

    // UI interaction on ship
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray forwardRay = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(forwardRay, out hit, sightDistance))
            {
                if(hit.transform.gameObject.tag == "Button")
                {
                    hit.transform.gameObject.GetComponent<Button>().onClick.Invoke();
                }
            }
        }
    }

    // Happens when pod is detached from main spaceship for landing
    public void StartPodDetach()
    {
        GameObject.Find("PodEject").GetComponent<Animator>().Play("podDetach");
    }


    public void EjectAnimationCamera()
    {
        StartCoroutine(StartPlanetLanding());
    }

    IEnumerator StartPlanetLanding()
    {
        GetComponent<Animator>().enabled = true;
        GetComponent<Animator>().Play("mountPod");
        yield return new WaitForSeconds(2f);
    }
}
