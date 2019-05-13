using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequencerLight : MonoBehaviour
{
    public Sprite onBulb;
    public void lightSequenceBulb()
    {       
        gameObject.GetComponent<Image>().sprite = onBulb;
        gameObject.GetComponent<Button>().interactable = true;
    }

    public void lightSequenceBulbError()
    {
        print("Sprite Error");
        gameObject.GetComponent<Button>().interactable = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
