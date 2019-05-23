using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    float sightDistance = 50f;
    public float fadeRate;
    public UIEffects detachButton;

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
           // GameObject tempCube = Instantiate(GameObject.Find("Cube"), forwardRay.origin, transform.rotation);
            //tempCube.GetComponent<Rigidbody>().AddForce(transform.forward*3f);
            //Debug.DrawRay(transform.position, transform.forward, Color.green, 2, false);
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
        //while (GetComponent<Animator>().is)
        GetComponent<Animator>().Play("mountPod");
        yield return new WaitForSeconds(2f);
        //GameObject.Find("PodEject").GetComponent<Animator>().Play("podDetach");
    }
}
