using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequencerManager : MonoBehaviour
{
    public SequencerLight[] sequencerLights;
    public GameObject shipNav;

    //timer
    public float timeLeft = 20f;
    public Text timerText;
    bool startTimer = true;
    int currentSequencer = 0;
    bool waitForNextSequencer = false;

    SequencerLight errorSequencerNum;
    public Button launchButton;


    // Start is called before the first frame update
    void setUpSequencerError()
    {
        errorSequencerNum = sequencerLights[Random.Range(0, sequencerLights.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            timerText.text = timeLeft.ToString("F1") + "s";
            if (timeLeft < 0)
            {
                LaunchReady();
            }
            else timeLeft -= Time.deltaTime;

            if (Mathf.Floor(timeLeft % sequencerLights.Length/2) == 0)
            {
                if (!waitForNextSequencer)
                {
                    if (sequencerLights[currentSequencer])
                    {
                        if (currentSequencer == 2)
                        {
                            sequencerLights[currentSequencer].lightSequenceBulbError();
                        }
                        else
                        {
                            if (sequencerLights[currentSequencer])
                            {
                                sequencerLights[currentSequencer].lightSequenceBulb();
                            }
                        }
                    }
                    currentSequencer++;
                    waitForNextSequencer = true;
                    StartCoroutine("SetupNextSequencer");
                }
            }
        }

    }

    public void PauseSequencerCountdown()
    {
        startTimer = false;
    }
    IEnumerator SetupNextSequencer()
    {
        yield return new WaitForSeconds(1.0f);
        waitForNextSequencer = false;
    }
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
    public void SwitchScreens()
    {
        gameObject.SetActive(false);
        shipNav.SetActive(true);
    }
    
}
