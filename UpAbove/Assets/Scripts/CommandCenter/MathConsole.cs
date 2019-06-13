using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Math UI
public class MathConsole : MonoBehaviour
{
    public GameObject previousCanvas;
    public GameObject mathProblemSource;
    
    //after you solve a math problem go back to the screen that you were at
    public void MathProblemSolved()
    {
        previousCanvas.SetActive(true);
        gameObject.SetActive(false);

        if (previousCanvas.name == "Sequencer_Canvas")
        {
            previousCanvas.GetComponent<SequencerManager>().ContinueCountdown();
            mathProblemSource.GetComponent<SequencerLight>().lightSequenceBulb();
            previousCanvas.GetComponent<SequencerManager>().StartLaunchTimer();

        }
        else if (previousCanvas.name == "ShipNav_Canvas")
        {
            previousCanvas.GetComponent<NavUI>().ShipProblemFixed();
        }
    }

    public void PauseCountdown()
    {
        previousCanvas.GetComponent<SequencerManager>().PauseSequencerCountdown();
    }

    public void SetMathProblemSource(GameObject sourceButton)
    {
        mathProblemSource = sourceButton;
    }

    public void SetPreviousCanvas(GameObject sourceCanvas)
    {
        previousCanvas = sourceCanvas;
    }
}
