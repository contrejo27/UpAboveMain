using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBehavior : MonoBehaviour
{
    public Sprite itemImage;
    public GameManager.ItemType ItemType;
    
    // Start is called before the first frame update
    public void Equip()
    {
        if (ItemType == GameManager.ItemType.Upgrade)
        {
            if (name == "jetpack")
            {
                PlayerPlanetBehavior.Instance.jetpackActivated = true;
                GameObject.Find("JetpackIcon").GetComponent<Image>().enabled = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
