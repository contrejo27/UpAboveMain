﻿using System.Collections;
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

    Color planetMaterialColor;
    void Start()
    {
        originalPos = camTransform.localPosition;

        StartCoroutine("FadeSky");
    }

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

    // Update is called once per frame
    void Update()
    {
        //print("shake " + shakeDuration);
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            shakeAmount *= .99f;
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }
}
