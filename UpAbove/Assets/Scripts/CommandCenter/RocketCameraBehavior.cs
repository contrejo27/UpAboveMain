using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCameraBehavior : MonoBehaviour
{
     public SequencerManager SequencerBehavior;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Launch()
    {
        GetComponent<Animator>().Play("Liftoff");
        StartCoroutine("NextScreen");
    }

    IEnumerator NextScreen()
    {
        yield return new WaitForSeconds(5f);
        SequencerBehavior.SwitchScreens();

    }
}
