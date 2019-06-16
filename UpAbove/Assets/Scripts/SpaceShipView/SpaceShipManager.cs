using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipManager : MonoBehaviour
{
    public GameObject planetSky;

    //Camera Shake
    // How long the object should shake for.
    public float shakeDuration = 10f;
    public Transform camTransform;
    Vector3 originalPos;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    bool launching = true;
    public GameObject[] spaceAsset;

    Color planetMaterialColor;

    // Launch starts as soon as scene starts but it should be moved to a button at some point
    void Start()
    {
        originalPos = camTransform.localPosition;

        StartCoroutine("FadeSky");
    }

    // Fades planet sky out to transparent so it looks like you're leaving the atmosphere
    IEnumerator FadeSky()
    {
        bool fading = true;
        yield return new WaitForSeconds(3f);

        while (fading)
        {
            planetMaterialColor = planetSky.GetComponent<Renderer>().material.color;
            planetSky.GetComponent<Renderer>().material.color = new Color(planetMaterialColor.r, planetMaterialColor.g, planetMaterialColor.b, planetMaterialColor.a - .005f);
            if(planetSky.GetComponent<Renderer>().material.color.a <0f) fading = false;

            yield return new WaitForSeconds(.01f);
        }
    }

    // Happens when you arrive to the space station
    public void UndockChair()
    {
        GetComponent<Animator>().Play("spaceShipUndock");
    }

    // Initial camera shake when launching. this should be triggered when launch happens right now it's just at start. 
    void Update()
    {
        print("shake " + shakeDuration);
        print("shake amnt" + shakeAmount);

        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            shakeAmount *= .99f;
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            launching = false;
            LoadNextSpaceAsset(spaceAsset[0]);
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }

    void LoadNextSpaceAsset(GameObject asset)
    {
        asset.SetActive(true);
    }

}
