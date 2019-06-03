using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Dots");
    }

    IEnumerator Dots()
    {
        Text loadingText = transform.GetChild(0).gameObject.GetComponent<Text>();
        while (true)
        {
            print(loadingText.text);
            if(loadingText.text == "Loading...") loadingText.text = "Loading";
            loadingText.text += ".";
            yield return new WaitForSeconds(.8f);
        }

    }
}
