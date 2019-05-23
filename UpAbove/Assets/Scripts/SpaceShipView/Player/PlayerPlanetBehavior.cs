using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPlanetBehavior : MonoBehaviour
{
    //how far you can shoot a teleport raycast
    float sightDistance = 100f;

    bool jetpackThrust = false;
    public bool jetpackActivated = false;
    //items
    public GameObject itemViewerParent;
    public GameObject descriptionBox;
    public GameObject storageConfirm;
    GameObject storageConfirmInstance;
    GameObject grabbedItem;

    public static PlayerPlanetBehavior Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        //if you tap, shoot a ray and check what it is
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray forwardRay = new Ray(transform.position, transform.forward);
            // GameObject tempCube = Instantiate(GameObject.Find("Cube"), forwardRay.origin, transform.rotation);
            //Debug.DrawRay(transform.position, transform.forward, Color.green, 200, false);
            if (Physics.Raycast(forwardRay, out hit, sightDistance))
            {

                //if not grabbing and you hit the land teleport.
                if (hit.transform.gameObject.name == "MarsTerrainLP")
                {
                    print("GroundTapped");
                    if (GameManager.Instance.currentPlayerState == GameManager.PlayerState.Grabbing)
                    {
                        DropItem();
                    }
                    else if (jetpackThrust == false)
                    {
                        StartCoroutine(Teleport(hit));

                    }
                }
                else if (hit.transform.gameObject.tag == "Item")
                {
                    grabbedItem = hit.transform.gameObject;
                    GameManager.Instance.itemHeld = grabbedItem;
                    GrabItem();
                }
                else if (hit.transform.gameObject.tag == "Button")
                {
                    print("ButtonPressed");
                    hit.transform.gameObject.GetComponent<Button>().onClick.Invoke();
                }

            }
            else
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                if(jetpackActivated) jetpackThrust = true;
            }

        }
        if (Input.GetButton("Fire1"))
        {
            if (jetpackThrust)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up *30 + Vector3.forward *6);
            }
        }

    }

    //when you collide with the ground, stay there
    private void OnCollisionEnter(Collision collision)
    {
        jetpackThrust = false;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;

    }

    IEnumerator Teleport(RaycastHit teleportRaycast)
    {
        Vector3 OGPos = transform.position;
        float slide = 0f;
        print("teleporting");
        while (slide<1.0f)
        {
            transform.position = Vector3.Lerp(OGPos, new Vector3(teleportRaycast.point.x, teleportRaycast.point.y + 4, teleportRaycast.point.z),slide);
            slide += .08f;

            yield return new WaitForSeconds(.01f) ;
        }
    }
    public void GrabItem()
    {
        GameManager.Instance.currentPlayerState = GameManager.PlayerState.Grabbing;    
        grabbedItem.GetComponent<Rigidbody>().useGravity = false;
        descriptionBox.SetActive(true);
        grabbedItem.GetComponent<BoxCollider>().enabled = false;
        grabbedItem.transform.position = itemViewerParent.transform.position;
        grabbedItem.transform.parent = itemViewerParent.transform;
        storageConfirmInstance = Instantiate(storageConfirm, transform.position, Quaternion.LookRotation(Camera.main.transform.forward));
        //storageConfirm.GetComponent<StorageUI>().HoldPosition();
    }

    public void DropItem()
    {
        GameManager.Instance.currentPlayerState = GameManager.PlayerState.Idle;
        grabbedItem.transform.parent = null;
        grabbedItem.GetComponent<BoxCollider>().enabled = true;
        grabbedItem.GetComponent<Rigidbody>().useGravity = true;
        descriptionBox.SetActive(false);
        GameManager.Instance.itemHeld = null;
        Destroy(storageConfirmInstance);
    }

    public void StartPodDetach()
    {
        GameObject.Find("PodEject").GetComponent<Animator>().Play("podDetach");
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
