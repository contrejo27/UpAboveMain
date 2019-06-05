using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<GameObject> itemsInInventory;
    public List<GameObject> itemsEquipped;
    public int maxInventory = 6;
    public GameObject itemHeld;
    public static InventoryManager Instance { get; private set; }
    public GameObject[] itemSlots;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    // Start is called before the first frame update
    public void AddItem()
    {
        GameObject.Find("DescriptionBox").SetActive(false);

        //make player idle
        GameManager.Instance.currentPlayerState = GameManager.PlayerState.Idle;

        //upgrade items will do special things when equipped
        if (itemHeld.GetComponent<ItemBehavior>().ItemType == GameManager.ItemType.Upgrade)
        {

            if (itemHeld.name == "jetpack")
            {
                print("equipping jetpack");
                PlayerPlanetBehavior.Instance.ActivateJetpack();
                GameObject.Find("JetpackIcon").GetComponent<Image>().enabled = true;
            }

            //keep track of equipped items
            itemsEquipped.Add(itemHeld.GetComponent<ItemBehavior>().itemPrefab);

        }
        else
        {
            //Show item slot in inventory with correct sprite
            print("grabbed research Item");
            itemSlots[itemsInInventory.Count].transform.GetChild(0).gameObject.SetActive(true);
            itemSlots[itemsInInventory.Count].transform.GetChild(0).GetComponent<Image>().sprite = itemHeld.GetComponent<ItemBehavior>().itemImage;
            itemsInInventory.Add(itemHeld.GetComponent<ItemBehavior>().itemPrefab);
        }

        Destroy(itemHeld);
    }

    public void PopulateStorageUI()
    {
        int itemPos = 0;
        print("populating " + itemsInInventory.Count);

        foreach (GameObject item in itemsInInventory)
        {
            print("populating " + item.name + " in " + itemPos);
            itemSlots[itemPos].transform.GetChild(0).gameObject.SetActive(true);
            itemSlots[itemPos].transform.GetChild(0).GetComponent<Image>().sprite = itemHeld.GetComponent<ItemBehavior>().itemImage;
            itemPos++;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
