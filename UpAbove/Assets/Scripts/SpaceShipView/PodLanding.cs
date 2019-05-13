using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodLanding : MonoBehaviour
{

    //Camera Shake
    // How long the object should shake for.
    public float shakeDuration = 10f;
    public Transform camTransform;
    Vector3 originalPos;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = camTransform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            shakeAmount *= .995f;
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }
}
