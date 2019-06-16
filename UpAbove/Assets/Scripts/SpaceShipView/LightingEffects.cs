using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightingEffects : MonoBehaviour
{
    public Light keyLight;
    public Light bounceLight;
    public Material podInside;
    public float fadeRate;
    public CanvasGroup screenEffect;



    //fade to complete white and then switch scenes

    public void FadeFromWhite()
    {
        StartCoroutine("StartFadeIn");
    }

    //fade from white to normal lighting
    IEnumerator StartFadeIn()
    {
        if (keyLight)
        {
            float OgKeyLightIntensity = keyLight.intensity;
            float OGAmbientIntensity = RenderSettings.ambientIntensity;
            float OGFogDensity = RenderSettings.fogDensity;
            float OGscreenEffect = screenEffect.alpha;
            for (float fadeAmount = 1.0f; fadeAmount > -.2; fadeAmount -= fadeRate / 1000)
            {
                yield return new WaitForSeconds(.01f);
                keyLight.intensity = Mathf.Lerp(OgKeyLightIntensity, 5, fadeAmount);
                RenderSettings.ambientIntensity = Mathf.Lerp(OGAmbientIntensity, 5, fadeAmount);
                //RenderSettings.fogDensity = Mathf.Lerp(OGFogDensity, .1f, fadeAmount);
                screenEffect.alpha = Mathf.Lerp(OGscreenEffect, 3, fadeAmount);
            }
        }
        else print("No Keylight assigned.");
    }
}
