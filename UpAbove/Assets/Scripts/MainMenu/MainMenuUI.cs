using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject[] UIs;
    // Start is called before the first frame update
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

    public void LaunchScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);

    }
}
