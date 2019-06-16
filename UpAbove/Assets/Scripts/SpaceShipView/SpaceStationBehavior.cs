using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationBehavior : MonoBehaviour
{
    public SpaceShipManager spaceShip;

    // Start is called before the first frame update
    public void DockShip()
    {
        spaceShip.GetComponent<Animator>().Play("Dock");
    }

}
