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
    
    IEnumerator StartFadeOut()
    {
        if (keyLight)
        {
            while (keyLight.intensity <= 11.0f)
            {
                yield return new WaitForSeconds(.01f);
                keyLight.intensity += fadeRate;
                RenderSettings.ambientIntensity += fadeRate*2.0f;
                RenderSettings.fogDensity += fadeRate *.0005f;
                screenEffect.alpha += fadeRate*.1f;
                bounceLight.intensity += fadeRate * .1f;
            }
            GameManager.Instance.LoadPlanet("Mars");
        }
    }

    public void FadeFromWhite()
    {
        StartCoroutine("StartFadeIn");
    }

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
