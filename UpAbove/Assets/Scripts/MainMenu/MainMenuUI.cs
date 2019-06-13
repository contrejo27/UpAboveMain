using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Main Menu Navigation
public class MainMenuUI : MonoBehaviour
{
    public GameObject[] UIs;
    public GameObject[] buttons;

    private void Start()
    {
        StartCoroutine("InitialAnimations");
    }


    public void GoToUI(string UIName)
    {
        foreach(GameObject UI in UIs)
        {
            if(UI.name == UIName)
            {
                UI.SetActive(true);
                return;
            }
        }
    }

    IEnumerator InitialAnimations()
    {
        yield return new WaitForSeconds(.5f);

        foreach (GameObject btn in buttons)
        {
            btn.SetActive(true);
            yield return new WaitForSeconds(.12f);
        }
    }
    public void LaunchScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);

    }
}
