using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//sequencer lightbulb behavior for command center. they turn on one by one till the end of the countdown
public class SequencerLight : MonoBehaviour
{
    public Sprite onBulb;

    //Turn on lightbulb green
    public void lightSequenceBulb()
    {       
        gameObject.GetComponent<Image>().sprite = onBulb;
        gameObject.GetComponent<Button>().interactable = true;
    }

    //turn on lightbulb error
    public void lightSequenceBulbError()
    {
        print("Sprite Error");
        gameObject.GetComponent<Button>().interactable = true;
    }
}
