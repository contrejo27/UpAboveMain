using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPlanetBehavior : MonoBehaviour
{
    //how far you can shoot a teleport raycast
    float sightDistance = 100f;
    bool jetpackActivated= false;

    bool jetpackThrust = false;
    //items
    public GameObject itemViewerParent;
    public GameObject descriptionBox;
    public GameObject storageConfirm;
    GameObject storageConfirmInstance;
    GameObject grabbedItem;
    public GameObject teleportSprite;

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

        RaycastHit hit;
        Ray forwardRay = new Ray(transform.position, transform.forward);
        //if the ray hits something
        if (Physics.Raycast(forwardRay, out hit, sightDistance))
        {

            //teleport hologram
            if (hit.transform.gameObject.name == "MarsTerrainLP")
            {
                teleportSprite.transform.position = new Vector3(hit.point.x, hit.point.y + .4f, hit.point.z);
            }

            // tap.
            if (Input.GetButtonDown("Fire1"))
            {
                //press button
                if (hit.transform.gameObject.tag == "Button")
                {
                    hit.transform.gameObject.GetComponent<Button>().onClick.Invoke();
                }
                //drop your item if you try and teleport with it. 
                if (GameManager.Instance.currentPlayerState == GameManager.PlayerState.Grabbing)
                {
                    DropItem();
                }
                //teleport if you aren't flying
                if (jetpackThrust == false && hit.transform.gameObject.name == "MarsTerrainLP")
                {
                    StartCoroutine(Teleport(hit));
                }
                //grab item   
                 if (hit.transform.gameObject.tag == "Item")
                {
                    grabbedItem = hit.transform.gameObject;
                    InventoryManager.Instance.itemHeld = grabbedItem;
                    GrabItem();
                }

        }
            // if you hit the sky then activate jetpack
        }

        if (Input.GetKey("space") && jetpackActivated)
        {
            jetpackThrust = true;

            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;

            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up *25 + Vector3.forward *6);
            
        }

    }

    public void ActivateJetpack()
    {
        print("Activating jetpack");
        jetpackActivated = true;
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
        if (!jetpackThrust) { 
            Vector3 OGPos = transform.position;
            float slide = 0f;
            while (slide<1.0f)
            {
                transform.position = Vector3.Lerp(OGPos, new Vector3(teleportRaycast.point.x, teleportRaycast.point.y + 3, teleportRaycast.point.z),slide);
                slide += .08f;

                yield return new WaitForSeconds(.01f) ;
            }
        }
    }
    public void GrabItem()
    {
        GameManager.Instance.currentPlayerState = GameManager.PlayerState.Grabbing;    
        grabbedItem.GetComponent<Rigidbody>().useGravity = false;

        //populate description box
        descriptionBox.SetActive(true);
        descriptionBox.transform.GetChild(0).GetComponent<Text>().text = grabbedItem.GetComponent<ItemBehavior>().itemTitle;
        descriptionBox.transform.GetChild(1).GetComponent<Text>().text = grabbedItem.GetComponent<ItemBehavior>().itemDescription;

        grabbedItem.GetComponent<BoxCollider>().enabled = false;
        grabbedItem.transform.position = itemViewerParent.transform.position;
        grabbedItem.transform.parent = itemViewerParent.transform;
        storageConfirmInstance = Instantiate(storageConfirm, transform.position, Quaternion.LookRotation(Camera.main.transform.forward));
        InventoryManager.Instance.PopulateStorageUI();
    }

    public void DropItem()
    {
        GameManager.Instance.currentPlayerState = GameManager.PlayerState.Idle;
        grabbedItem.transform.parent = null;
        grabbedItem.GetComponent<BoxCollider>().enabled = true;
        grabbedItem.GetComponent<Rigidbody>().useGravity = true;
        descriptionBox.SetActive(false);
        InventoryManager.Instance.itemHeld = null;
        storageConfirmInstance.SetActive(false);
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
