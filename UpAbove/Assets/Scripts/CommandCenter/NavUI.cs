using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//used for the navigation UI in the command center. 
public class NavUI : MonoBehaviour
{
    //path finding
    public Transform[] wayPointList;
    public int currentWayPoint = 0;
    Transform targetWayPoint;
    public float shipSpeed;

    //UI
    public GameObject shipIcon;
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

    //Trigger error that makes ship blink. you have to tap it and solve a math problem.
    IEnumerator TriggerShipError()
    {
        yield return new WaitForSeconds(4f);
        ShipError();
    }

    //trigger blinking
    void ShipError()
    {
        ogShipColor = shipIcon.GetComponent<Image>().color;
        StartCoroutine("ShipBlinking");
    }

    //blinks from red to normal color
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

    //once math problem is done, return ship to normal color
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
