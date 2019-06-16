using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public void ToggleGameObjectActive(GameObject GOToActivate)
    {
        if(GOToActivate.activeSelf)
        {
            GOToActivate.SetActive(false);
        }
        else
        {
            GOToActivate.SetActive(true);
        }
    }
}
