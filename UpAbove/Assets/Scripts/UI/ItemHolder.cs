using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHolder : MonoBehaviour
{
    public GameObject[] itemSlots;

    public void addNewItem()
    {
        GameManager.Instance.itemHeld.GetComponent<ItemBehavior>().Equip();
        itemSlots[0].transform.GetChild(0).gameObject.SetActive(true);
        itemSlots[0].transform.GetChild(0).GetComponent<Image>().sprite = GameManager.Instance.itemHeld.GetComponent<ItemBehavior>().itemImage;
        //TODO: Set up better way to keep all item UI under one script
        GameObject.Find("DescriptionBox").SetActive(false);
        Destroy(GameManager.Instance.itemHeld);
        Destroy(transform.parent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
