using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SequencerManager : MonoBehaviour
{
    //UI
    public SequencerLight[] sequencerLights;
    public GameObject shipNav;
    SequencerLight errorSequencerNum;
    public Button launchButton;

    //timer
    public float timeLeft = 20f;
    public Text timerText;
    bool startTimer = true;
    int currentSequencer = 0;
    bool waitForNextSequencer = false;



    // pick a sequencer to do an error with. The error is something you have to fix. 
    void setUpSequencerError()
    {
        errorSequencerNum = sequencerLights[Random.Range(0, sequencerLights.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        //timer for sequencer lights
        if (startTimer)
        {
            //timer UI
            timerText.text = timeLeft.ToString("F1") + "s";

            //keep subtracting timer until launch is ready
            if (timeLeft < 0)
            {
                LaunchReady();
            }
            else timeLeft -= Time.deltaTime;

            // bulbs light up as time gos by 
            if (Mathf.Floor(timeLeft % sequencerLights.Length/2) == 0)
            {
                //wait for coroutine to turn on next lightbulb
                if (!waitForNextSequencer)
                {
                    if (sequencerLights[currentSequencer])
                    {
                        //hardcoded lightbulb error, TODO: Make lightbulb error random
                        if (currentSequencer == 2)
                        {
                            sequencerLights[currentSequencer].lightSequenceBulbError();
                        }
                        else
                        {
                            //light sequencer
                            if (sequencerLights[currentSequencer])
                            {
                                sequencerLights[currentSequencer].lightSequenceBulb();
                            }
                        }
                    }
                    //go to next light and wait
                    currentSequencer++;
                    waitForNextSequencer = true;
                    StartCoroutine("SetupNextSequencer");
                }
            }
        }

    }

    //pause countdown for math problem
    public void PauseSequencerCountdown()
    {
        startTimer = false;
    }

    // Wait some time and light up next sequencer. 
    IEnumerator SetupNextSequencer()
    {
        yield return new WaitForSeconds(1.0f);
        waitForNextSequencer = false;
    }

    // continue countdown after math problem
    public void ContinueCountdown()
    {
        waitForNextSequencer = false;
    }

    
    public void StartLaunchTimer()
    {
        startTimer = true;
    }

    public void CancelLaunchTimer()
    {
        startTimer = false;
    }

    void LaunchReady()
    {
        launchButton.interactable = true;
    }

    //go to next screen.
    public void SwitchScreens()
    {
        gameObject.SetActive(false);
        shipNav.SetActive(true);
    }
    
}
