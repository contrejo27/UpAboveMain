using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavUI : MonoBehaviour
{
    public GameObject shipIcon;
    public Transform[] wayPointList;

    public int currentWayPoint = 0;
    Transform targetWayPoint;

    public float shipSpeed;

    Color ogShipColor;
    bool blinking;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("TriggerShipError");
    }

    // Update is called once per frame
    void Update()
    {
        // check if we have somewere to walk
        if (currentWayPoint < this.wayPointList.Length)
        {
            if (targetWayPoint == null)
                targetWayPoint = wayPointList[currentWayPoint];
            walk();
        }
    }

    IEnumerator TriggerShipError()
    {
        yield return new WaitForSeconds(4f);
        ShipError();
    }

    void ShipError()
    {
        ogShipColor = shipIcon.GetComponent<Image>().color;

        StartCoroutine("ShipBlinking");
    }

    IEnumerator ShipBlinking()
    {
        blinking = true;
        bool red = false;
        while (blinking)
        {
            if (!red)
            {
                shipIcon.GetComponent<Image>().color = Color.red;
                red = true;
            }
            else
            { 
                shipIcon.GetComponent<Image>().color = ogShipColor;
                red = false;
            }
            yield return new WaitForSeconds(.3f);
        }
    }

    public void ShipProblemFixed()
    {
        shipIcon.GetComponent<Image>().color = ogShipColor;
    }
    void walk()
    {
        // rotate towards the target. TODO: Not Working
        //shipIcon.transform.up = Vector3.RotateTowards(shipIcon.transform.forward, targetWayPoint.position - shipIcon.transform.position, shipSpeed * Time.deltaTime, 0.0f);

        // move towards the target
        shipIcon.transform.position = Vector3.MoveTowards(shipIcon.transform.position, targetWayPoint.position, shipSpeed * Time.deltaTime);

        if (shipIcon.transform.position == targetWayPoint.position)
        {
            currentWayPoint++;
            targetWayPoint = wayPointList[currentWayPoint];
        }
    }
}
