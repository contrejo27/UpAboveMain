using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHolder : MonoBehaviour
{

    //TODO: migrate all this to inventory manager or item behavior or storage UI
    public void addNewItem()
    {
        GameObject.Find("DescriptionBox").SetActive(false);
        InventoryManager.Instance.AddItem();
        Destroy(gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
