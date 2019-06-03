﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    float sightDistance = 40f;
    public float fadeRate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
